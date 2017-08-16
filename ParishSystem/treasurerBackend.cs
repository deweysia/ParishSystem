using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;



namespace ParishSystem
{
    class treasurerBackend :DataHandler
    {
        
        public treasurerBackend()
        {
                    }
        public DataTable getAllItemTypesOfBook(int b)
        {
            string q = $"select * from itemtype where booktype = {b}";
            return runQuery(q);
        }
        public DataTable searchByOR(int OR, int BookType)
        {
            string q = $@"select ORnum, sourceName,primaryIncomeDateTime,remarks,primaryincome.primaryIncomeID,bookType, sum(price) as price ,sum(amount) as amount
                        from primaryincome left outer join item on item.primaryIncomeID= primaryincome.primaryIncomeID left outer join payment on payment.primaryIncomeID= primaryincome.primaryIncomeID
                        where
                        bookType = 1 and ORnum like '%{OR}%'
                        group by  ORnum
                        order by ORnum desc";
            return runQuery(q);
        }

        public DataTable getTransactions(int BookType)
        {
            string q = $@"select ORnum, sourceName,primaryIncomeDateTime,remarks,primaryincome.primaryIncomeID,bookType, sum(price) as price ,sum(amount) as amount
                        from primaryincome left outer join item on item.primaryIncomeID= primaryincome.primaryIncomeID left outer join payment on payment.primaryIncomeID= primaryincome.primaryIncomeID
                        where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and bookType = {BookType}
                        group by  ORnum
                        order by ORnum desc";
            return runQuery(q);
        }
        public DataTable getTransactionSummary(int BookType)
        {
            string q = $@"select itemtype.itemType, sum(price) from primaryincome inner join item on item.primaryIncomeID = primaryincome.primaryincomeid inner join itemtype on item.itemTypeID = itemtype.itemTypeID
                        where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and primaryincome.bookType = {BookType}
                        group by itemtype.itemtypeid
                        order by itemtype.itemType asc; ";
            return runQuery(q);
        }
        public DataTable getTransactionsOnDay( int bookType, int day, int month, int year)
        {
            string q = $@"SELECT * FROM primaryincome left outer join item on item.primaryIncomeID = primaryincome.primaryIncomeID 
                        left outer join payment on payment.primaryIncomeID=primaryincome.primaryincomeid 
                        where  DAY(primaryIncomeDateTime) = {day} and MONTH(primaryIncomeDateTime) = {month} and YEAR(primaryIncomeDateTime) = {year} and bookType = {bookType}";
            return runQuery(q);
        }
        public DataTable getTransactionsOnMonth( int bookType, int month, int year )
        {
            string q = $@"SELECT * FROM primaryincome left outer join item on item.primaryIncomeID = primaryincome.primaryIncomeID 
                        left outer join payment on payment.primaryIncomeID=primaryincome.primaryincomeid 
                        where  YEAR(primaryIncomeDateTime) = {year} AND MONTH(primaryIncomeDateTime) = {month} and bookType = {bookType}";
            return runQuery(q);
        }
        public DataTable getTransactionsOnYear( int bookType , int year)
        {
            string q = $@"SELECT * FROM primaryincome left outer join item on item.primaryIncomeID = primaryincome.primaryIncomeID 
                         left outer join payment on payment.primaryIncomeID=primaryincome.primaryincomeid 
                        where  YEAR(primaryIncomeDateTime) = {year} and bookType = {bookType}";
            return runQuery(q);
        }
        public DataTable getTransactionsInBetweenDates(int bookType, DateTime from, DateTime to)
        {
            string q = $@"select ORnum, sourceName,primaryIncomeDateTime,remarks,primaryincome.primaryIncomeID,bookType, sum(price) as price ,sum(amount) as amount
                        from primaryincome left outer join item on item.primaryIncomeID= primaryincome.primaryIncomeID left outer join payment on payment.primaryIncomeID= primaryincome.primaryIncomeID
                        where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and bookType = {bookType}
                        group by  ORnum
                        order by ORnum desc";
            return runQuery(q);
        }

        public DataTable getTransactionsByAccountingBookFormatByOrNumber(int BookType,int OR)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where primaryincome.booktype = {BookType} and 
                            ORnum like '%{OR}%'
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where primaryincome.booktype = {BookType} and 
                            ORnum like '%{OR}%'
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByDay(int BookType ,int Day, int Month ,int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where DAY(primaryIncomeDateTime) = {Day} and MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where DAY(primaryIncomeDateTime) = {Day} and MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByMonth(int BookType, int Month, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where MONTH(primaryIncomeDateTime) = {Month} and YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatByYear(int BookType, int Year)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where YEAR(primaryIncomeDateTime) = {Year} and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatBetweenDates(int BookType, DateTime from, DateTime to)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                            and primaryIncome.bookType = { BookType }
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                            where(primaryIncomeDateTime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                            and primaryIncome.bookType = { BookType }
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsByAccountingBookFormatRecent(int BookType)
        {
            string q = $@"select * from (select primaryincome.primaryIncomeID, sourceName, primaryincome.bookType ,ORnum,primaryIncomeDateTime,price,itemType from primaryincome 
                            inner join item on item.primaryIncomeID = primaryincome.primaryincomeid 
                            inner join itemtype on item.itemTypeID=itemtype.itemTypeID 
                            where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                            and primaryIncome.bookType = {BookType}
                            union
                            select primaryincome.primaryIncomeID,sourceName,primaryincome.bookType,ORnum,primaryIncomeDateTime,amount,itemType from primaryincome 
                            inner join payment on payment.primaryIncomeID = primaryincome.primaryIncomeID 
                            inner join sacramentincome on sacramentincome.sacramentIncomeID = payment.sacramentIncomeID 
                            inner join application on application.applicationID = sacramentincome.applicationID 
                            inner join itemtype on itemtype.itemTypeID = application.sacramentType 
                             where(primaryIncomeDateTime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                             and primaryIncome.bookType = {BookType}
                            ) as A  order by ORnum desc;";
            return runQuery(q);
        }
        //--------------------------------------------------------------------------------------------------------------//
        //Def: total-summation of transactions per row
        //     breakdown- in 1 row you can see all items in an OR
        //     grouped- groups all OR in 1 day
        //     ungrouped- shows individual OR
        public DataTable getSummaryCashDisbursment(DataTable transactions,int bookType)//summary tab
        {
            DataTable allitems = getAllItemTypesOfBook(bookType);
            Dictionary<string, float> itemtypes = new Dictionary<string, float>();

            foreach (DataRow dr in allitems.Rows)
            {
                itemtypes.Add(dr["itemType"].ToString(),0);
            }

            foreach (DataRow dr in transactions.Rows)
            {
                if (itemtypes.ContainsKey(dr["itemType"].ToString()))
                {
                    itemtypes[dr["itemtype"].ToString()] = float.Parse(itemtypes[dr["itemtype"].ToString()].ToString()) + float.Parse(dr["price"].ToString());
                }
            }
            DataTable output = new DataTable();
            output.Columns.Add("Type",typeof(string));
            output.Columns.Add("Sum", typeof(float));
            foreach (KeyValuePair<string, float> entry in itemtypes)
            {
                if (entry.Value != 0)
                {
                    output.Rows.Add(entry.Key,entry.Value);
                }
            }
            return output;
        }
        public DataTable getTotalUngroupedCashDisbursment(DataTable transactions)//total ungrouped
        {
            DataTable output = new DataTable();
            int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
            DataRow row = output.NewRow();

            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in transactions.Rows)
            {
                if (currentOR != int.Parse(dr["ORnum"].ToString()))
                {
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentOR = int.Parse(dr["ORnum"].ToString());
                }
                row["OR Number"] = dr["ORnum"].ToString();
                row["Name"] = dr["SourceName"].ToString();
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                try { row["Amount"] = float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString()); } catch { row["Amount"]= float.Parse(dr["price"].ToString()); };
            }
            output.Rows.Add(row);
            return output;
        }
        public DataTable getTotalGroupedCashDisbursment(DataTable transactions)//total grouped
        {
            DataTable output = new DataTable();
            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Date Paid", typeof(string));
            DataRow row = output.NewRow();
                DateTime currentDate = toDateTime(transactions.Rows[0]["primaryIncomeDateTime"].ToString(), false);
                int minOR = int.MaxValue;
                int maxOR = 0;

                foreach (DataRow dr in transactions.Rows)
                {
                    if (!currentDate.Equals(toDateTime(dr["primaryIncomeDateTime"].ToString(), false)))
                    {
                        row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
                        output.Rows.Add(row);
                        row = output.NewRow();
                        currentDate = toDateTime(dr["primaryIncomeDateTime"].ToString(), false);
                        minOR = int.MaxValue;
                        maxOR = 0;
                    }
                    row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                    if (minOR > int.Parse(dr["ORnum"].ToString()))
                    {
                        minOR = int.Parse(dr["ORnum"].ToString());
                    }

                    if (maxOR < int.Parse(dr["ORnum"].ToString()))
                    {
                        maxOR = int.Parse(dr["ORnum"].ToString());
                    }
                    row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                    try { row["Amount"] = float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString()); } catch { row["Amount"] = float.Parse(dr["price"].ToString()); };
                }
                row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
                output.Rows.Add(row);  
            return output;
        }
        public DataTable getBreakdownUngroupedCashDisbursment(DataTable transactions, int bookType)//breakdown ungrouped
        {
            DataTable output = new DataTable();
            DataTable itemTypes = getAllItemTypesOfBook(bookType);

            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in itemTypes.Rows)
            {
                output.Columns.Add(dr["itemType"].ToString(),typeof(float)); //add columns 
                output.Columns[dr["itemType"].ToString()].DefaultValue = 0;
               
            }

            int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
            DataRow row = output.NewRow();
            foreach (DataRow dr in transactions.Rows)
            {
                if (currentOR != int.Parse(dr["ORnum"].ToString()))
                {

                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentOR = int.Parse(dr["ORnum"].ToString());
                }
                row["OR Number"] = dr["ORnum"].ToString();
                row["Name"] = dr["SourceName"].ToString();
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(),true).ToString("MMMM dd yyyy, hh-mm");
                row[dr["itemType"].ToString()] =(row[dr["itemType"].ToString()]==null ? 0:float.Parse(row[dr["itemType"].ToString()].ToString())) + float.Parse(dr["price"].ToString());
            }
            output.Rows.Add(row);

            return output;
        }
        public DataTable getBreakdownGroupedCashDisbursment(DataTable transactions,int bookType) //breakdown grouped
        {
            DateTime currentDate = toDateTime(transactions.Rows[0]["primaryIncomeDateTime"].ToString(), false);
            int minOR = int.MaxValue;
            int maxOR = 0;
        
            DataTable output = new DataTable();
            DataTable itemTypes = getAllItemTypesOfBook(bookType);

            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in itemTypes.Rows)
            {
                output.Columns.Add(dr["itemType"].ToString(), typeof(float)); //add columns 
                output.Columns[dr["itemType"].ToString()].DefaultValue = 0;
            }
            int currentOR = int.Parse(transactions.Rows[0]["ORnum"].ToString());
            DataRow row = output.NewRow();
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["primaryIncomeDateTime"].ToString(), false)))
                {
                    row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["primaryIncomeDateTime"].ToString(), false);
                    minOR = int.MaxValue;
                    maxOR = 0;
                }
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minOR > int.Parse(dr["ORnum"].ToString()))
                {
                    minOR = int.Parse(dr["ORnum"].ToString());
                }

                if (maxOR < int.Parse(dr["ORnum"].ToString()))
                {
                    maxOR = int.Parse(dr["ORnum"].ToString());
                }
                //per itemtype code starts here
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                row[dr["itemType"].ToString()] = (row[dr["itemType"].ToString()] == null ? 0 : float.Parse(row[dr["itemType"].ToString()].ToString())) + float.Parse(dr["price"].ToString());
                //per item type code ends here
            }
            row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
            output.Rows.Add(row);

            return output;
        }
        /*  LMAOOO this is the same as getTotalSummaryOfTransactionsOnOrRange >> im so stupid for recoding
        public DataTable getDayRangeSummaryOfTransactions(DataTable transactions) //sum of tranasctions per or range
        {
            DataTable output = new DataTable();
            output.Columns.Add("OR Number", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Date Paid", typeof(string));
            DataRow row = output.NewRow();
            DateTime currentDate = toDateTime(transactions.Rows[0]["primaryIncomeDateTime"].ToString(),false);
            int minOR = int.MaxValue;
            int maxOR = 0;
            float amount = 0;   
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["primaryIncomeDateTime"].ToString(), false)))
                {
                    row["OR Number"] = minOR.ToString()+"-"+ maxOR.ToString();
                    row["Amount"] = amount;
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["primaryIncomeDateTime"].ToString(), false);
                    minOR = int.MaxValue;
                    maxOR = 0;
                    amount = 0;
                }
                row["Date Paid"] = toDateTime(dr["primaryincomedatetime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minOR > int.Parse(dr["ORnum"].ToString()))
                {
                    minOR = int.Parse(dr["ORnum"].ToString());
                }

                if (maxOR < int.Parse(dr["ORnum"].ToString()))
                {
                    maxOR = int.Parse(dr["ORnum"].ToString());
                }
                amount += ((dr["price"].ToString() != "") ? float.Parse(dr["price"].ToString()) : float.Parse(dr["amount"].ToString()));
            }
            row["Date Paid"] = currentDate.ToString("MMMM dd yyyy");
            row["OR Number"] = minOR.ToString() + "-" + maxOR.ToString();
            row["Amount"] = amount;
            output.Rows.Add(row);
            return output;
        }
        */
        //--------------------------------------------------------------------------------------------------------------//
        public int getMaxCNNumber(int book)
        {
            string q = $@"select max(checkNum) from cashreleasevoucher where booktype = {book}";
            int holder=1;
            if (int.TryParse(runQuery(q).Rows[0][0].ToString(), out holder))
            {
                return holder+1;
            }
            return 1;
        }
        public int getMaxCVNumber(int book)
        {
            string q = $@"select max(CVnum) from cashreleasevoucher where booktype = {book}";
            int holder = 1;
            if (int.TryParse(runQuery(q).Rows[0][0].ToString(), out holder))
            {
                return holder+1;
            }
            return 1;
        }
        public DataTable getItemTypesCashRelease(int bookType)
        {
            string q = $@"select * from cashreleasetype where booktype ={bookType} and status =1";
            return runQuery(q);
        }
        public int addCashRelease(string remark, int checkNum, int CVnum, int bookType ,string name)
        {
            string q = $@"INSERT INTO `sad2`.`cashreleasevoucher` (`cashReleaseDateTime`, `remark`, `checkNum`, `CVnum`, `bookType`, `name`) VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{remark}', '{checkNum}', '{CVnum}', '{bookType}','{name}'); SELECT LAST_INSERT_ID()" ;
            return int.Parse(runQuery(q).Rows[0][0].ToString());
        }
        public void addCashReleaseItem(int CashReleaseVoucherID, int cashReleaseTypeID, decimal releaseAmount)
        {
            string q = $@"INSERT INTO `sad2`.`cashreleaseitem` (`CashReleaseVoucherID`, `cashReleaseTypeID`, `releaseAmount`) VALUES ('{CashReleaseVoucherID}', '{cashReleaseTypeID}', '{releaseAmount}')";
            runNonQuery(q);
        }

        public DataTable getTransactionsCRBByAccountingBookFormatByOrNumber(int BookType, int checknum,int CVnum)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN cashreleasetype on cashReleaseType.cashreleasetypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        cashreleasetype.booktype = {BookType} and 
                        checknum like '%{checknum}%' and
                        CVnum like '%{CVnum}%'
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatByDay(int BookType, int Day, int Month, int Year)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN cashreleasetype on cashReleaseType.cashreleasetypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where 
                        cashreleasetype.booktype = {BookType} and 
						DAY(cashReleaseDateTime) = {Day} and MONTH(cashReleaseDateTime) = {Month} and YEAR(cashReleaseDateTime) = {Year}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatByMonth(int BookType, int Month, int Year)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN cashreleasetype on cashReleaseType.cashreleasetypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where MONTH(cashReleaseDateTime) = {Month} and YEAR(cashReleaseDateTime) = {Year}
                        and cashreleasevoucher.bookType = {BookType}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatByYear(int BookType, int Year)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN cashreleasetype on cashReleaseType.cashreleasetypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where YEAR(cashReleaseDateTime) = {Year}
                        and cashreleasevoucher.bookType = {BookType}
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatBetweenDates(int BookType, DateTime from, DateTime to)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN cashreleasetype on cashReleaseType.cashreleasetypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where(cashreleasedatetime between '{ from.ToString("yyyy-MM-dd hh:mm:ss")}' and '{to.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and cashreleasevoucher.bookType = { BookType }
                        order by CVnum desc;";
            return runQuery(q);
        }
        public DataTable getTransactionsCRBByAccountingBookFormatRecent(int BookType)
        {
            string q = $@"SELECT * FROM cashreleaseitem 
                        INNER JOIN cashreleasetype on cashReleaseType.cashreleasetypeID = cashreleaseitem.cashReleaseTypeID 
                        INNER JOIN cashreleasevoucher on cashreleasevoucher.cashreleasevoucherid = cashreleaseitem.CashReleaseVoucherID 
                        where(cashreleasedatetime between '{ (DateTime.Now - new TimeSpan(7, 0, 0, 0)).ToString("yyyy-MM-dd hh:mm:ss")}' and '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}')
                        and cashreleasevoucher.bookType = {BookType}
                        order by CVnum desc;";
            return runQuery(q);
        }

        public DataTable getSummaryCashRelease(DataTable transactions, int bookType)//summary tab
        {
            DataTable allitems = getItemTypesOfCashRelease(bookType);
            Dictionary<string, float> itemtypes = new Dictionary<string, float>();

            foreach (DataRow dr in allitems.Rows)
            {
                itemtypes.Add(dr["cashReleaseType"].ToString(), 0);
            }

            foreach (DataRow dr in transactions.Rows)
            {
                if (itemtypes.ContainsKey(dr["cashReleaseType"].ToString()))
                {
                    itemtypes[dr["cashReleaseType"].ToString()] = float.Parse(itemtypes[dr["cashReleaseType"].ToString()].ToString()) + float.Parse(dr["releaseAmount"].ToString());
                }
            }
            DataTable output = new DataTable();
            output.Columns.Add("Type", typeof(string));
            output.Columns.Add("Sum", typeof(float));
            foreach (KeyValuePair<string, float> entry in itemtypes)
            {
                if (entry.Value != 0)
                {
                    output.Rows.Add(entry.Key, entry.Value);
                }
            }
            return output;
        }
        public DataTable getTotalUngroupedCashRelease(DataTable transactions)//total ungrouped
        {
            DataTable output = new DataTable();
            int currentOR = int.Parse(transactions.Rows[0]["CVnum"].ToString());
            DataRow row = output.NewRow();

            output.Columns.Add("CVnum", typeof(string));
            output.Columns.Add("checkNum", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in transactions.Rows)
            {
                if (currentOR != int.Parse(dr["CVnum"].ToString()))
                {
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentOR = int.Parse(dr["CVnum"].ToString());
                }
                row["CVnum"] = dr["CVnum"].ToString();
                row["checkNum"] = dr["checkNum"].ToString();
                row["Name"] = dr["name"].ToString();
                row["Date Paid"] = toDateTime(dr["cashReleaseDateTime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                try { row["Amount"] = float.Parse(row["Amount"].ToString()) + float.Parse(dr["price"].ToString()); } catch { row["Amount"] = float.Parse(dr["releaseAmount"].ToString()); };
            }
            output.Rows.Add(row);
            return output;
        }
        public DataTable getTotalGroupedCashRelease(DataTable transactions)//total grouped
        {
            DataTable output = new DataTable();
            output.Columns.Add("CVnum", typeof(string));
            output.Columns.Add("checkNum", typeof(string));
            output.Columns.Add("Amount", typeof(float));
            output.Columns.Add("Date Paid", typeof(string));
            DataRow row = output.NewRow();
            DateTime currentDate = toDateTime(transactions.Rows[0]["cashReleaseDateTime"].ToString(), false);
            int minCV = int.MaxValue;
            int maxCV = 0;
            int minCN = int.MaxValue;
            int maxCN = 0;
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["cashReleaseDateTime"].ToString(), false)))
                {
                    row["CVnum"] = minCV.ToString() + "-" + maxCV.ToString();
                    row["checkNum"] = minCN.ToString() + "-" + maxCN.ToString();
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["cashReleaseDateTime"].ToString(), false);
                     minCV = int.MaxValue;
                     maxCV = 0;
                     minCN = int.MaxValue;
                     maxCN = 0;
                }
                row["Date Paid"] = toDateTime(dr["cashReleaseDateTime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minCV > int.Parse(dr["CVnum"].ToString()))
                {
                    minCV = int.Parse(dr["CVnum"].ToString());
                    minCN = int.Parse(dr["checkNum"].ToString());
                }

                if (maxCV < int.Parse(dr["CVnum"].ToString()))
                {
                    maxCV = int.Parse(dr["CVnum"].ToString());
                    maxCN = int.Parse(dr["checkNum"].ToString());
                }
                row["Date Paid"] = toDateTime(dr["cashReleaseDateTime"].ToString(), true).ToString("MMMM dd yyyy");
                try { row["Amount"] = float.Parse(row["Amount"].ToString()) + float.Parse(dr["releaseAmount"].ToString()); } catch { row["Amount"] = float.Parse(dr["releaseAmount"].ToString()); };
            }
            row["CVnum"] = minCV.ToString() + "-" + maxCV.ToString();
            row["checkNum"] = minCN.ToString() + "-" + maxCN.ToString();
            output.Rows.Add(row);
            return output;
        }
        public DataTable getBreakdownUngroupedCashRelease(DataTable transactions, int bookType)//breakdown ungrouped
        {
            DataTable output = new DataTable();
            DataTable itemTypes = getItemTypesOfCashRelease(bookType);

            output.Columns.Add("CVnum", typeof(string));
            output.Columns.Add("checkNum", typeof(string));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in itemTypes.Rows)
            {
                output.Columns.Add(dr["cashReleaseType"].ToString(), typeof(float)); //add columns 
                output.Columns[dr["cashReleaseType"].ToString()].DefaultValue = 0;

            }

            int currentOR = int.Parse(transactions.Rows[0]["CVnum"].ToString());
            DataRow row = output.NewRow();
            foreach (DataRow dr in transactions.Rows)
            {
                if (currentOR != int.Parse(dr["CVnum"].ToString()))
                {

                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentOR = int.Parse(dr["CVnum"].ToString());
                }
                row["CVnum"] = dr["CVnum"].ToString();
                row["checkNum"] = dr["checkNum"].ToString();
                row["Name"] = dr["name"].ToString();
                row["Date Paid"] = toDateTime(dr["cashReleaseDateTime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                row[dr["cashReleaseType"].ToString()] = (row[dr["cashReleaseType"].ToString()] == null ? 0 : float.Parse(row[dr["cashReleaseType"].ToString()].ToString())) + float.Parse(dr["releaseAmount"].ToString());
            }
            output.Rows.Add(row);

            return output;
        }
        public DataTable getBreakdownGroupedCashRelease(DataTable transactions, int bookType) //breakdown grouped
        {
            DateTime currentDate = toDateTime(transactions.Rows[0]["cashReleaseDateTime"].ToString(), false);
            DataTable output = new DataTable();
            DataTable itemTypes = getItemTypesOfCashRelease(bookType);

            output.Columns.Add("CVnum", typeof(string));
            output.Columns.Add("checkNum", typeof(string));
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Date Paid", typeof(string));

            foreach (DataRow dr in itemTypes.Rows)
            {
                output.Columns.Add(dr["cashReleaseType"].ToString(), typeof(float)); //add columns 
                output.Columns[dr["cashReleaseType"].ToString()].DefaultValue = 0;
            }

            int minCV = int.MaxValue;
            int maxCV = 0;
            int minCN = int.MaxValue;
            int maxCN = 0;

            DataRow row = output.NewRow();
            foreach (DataRow dr in transactions.Rows)
            {
                if (!currentDate.Equals(toDateTime(dr["cashReleaseDateTime"].ToString(), false)))
                {
                    row["CVnum"] = minCV.ToString() + "-" + maxCV.ToString();
                    row["checkNum"] = minCN.ToString() + "-" + maxCN.ToString();
                    output.Rows.Add(row);
                    row = output.NewRow();
                    currentDate = toDateTime(dr["cashReleaseDateTime"].ToString(), false);
                     minCV = int.MaxValue;
                     maxCV = 0;
                     minCN = int.MaxValue;
                     maxCN = 0;
                }
                row["Date Paid"] = toDateTime(dr["cashReleaseDateTime"].ToString(), true).ToString("MMMM dd yyyy");
                if (minCV > int.Parse(dr["CVnum"].ToString()))
                {
                    minCV = int.Parse(dr["CVnum"].ToString());
                    minCN = int.Parse(dr["checkNum"].ToString());
                }

                if (maxCV < int.Parse(dr["CVnum"].ToString()))
                {
                    maxCV = int.Parse(dr["CVnum"].ToString());
                    maxCN = int.Parse(dr["checkNum"].ToString());
                }
                //per itemtype code starts here
                row["Date Paid"] = toDateTime(dr["cashReleaseDateTime"].ToString(), true).ToString("MMMM dd yyyy, hh-mm");
                row[dr["cashReleaseType"].ToString()] = (row[dr["cashReleaseType"].ToString()] == null ? 0 : float.Parse(row[dr["cashReleaseType"].ToString()].ToString())) + float.Parse(dr["releaseAmount"].ToString());
                //per item type code ends here
            }
            row["CVnum"] = minCV.ToString() + "-" + maxCV.ToString();
            row["checkNum"] = minCN.ToString() + "-" + maxCN.ToString();
            output.Rows.Add(row);

            return output;
        }

        public DataTable getItemTypesOfCashRelease(int bookType)
        {
            string q = $@"SELECT * FROM sad2.cashreleasetype where bookType = {bookType}";
            return runQuery(q);
        }

    }
}
