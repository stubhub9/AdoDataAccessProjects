//  Connection Factory  Console App

//  #if PC is declared here, appPropGrpDefConst, and appProp buildCompSym 
using System.Data;
using System.Data.Odbc;
#if PC
using System.Data.OleDb;
#endif
using Microsoft.Data.SqlClient;
using MyConnectionFactory;


//re:  Top Level Statements????
//  ?  Are properties console valid?
//public ConsoleColor NewColor
//{
//	get { return newColor; }
//	set { newColor = value; }
//}
#region  Fields  -program-main

ConsoleColor backGroundColor = Console.BackgroundColor;
ConsoleColor newColor = ConsoleColor.DarkBlue;


#endregion Fields -program-main
#region Program-Main


Console.BackgroundColor = newColor;
Console.Clear ();


Console.BackgroundColor = NewColor ( ref newColor );
Console.WriteLine ( "*****    Very Simple Connection Factory  setThemAllUp     *****" );
Setup ( DataProviderEnum.SqlServer );
#if PC
Setup ( DataProviderEnum.OleDb );
#endif
Setup ( DataProviderEnum.Odbc );
Setup ( DataProviderEnum.None );





Console.BackgroundColor = NewColor ( ref newColor );
Console.WriteLine ( "EOP" );
//Console.ReadLine ();

//  Background.Dispose +/-
Console.BackgroundColor = backGroundColor;


#endregion Program-Main
#region Methods

static ConsoleColor NewColor ( ref ConsoleColor newColor)
{
    newColor++;
    if ( newColor == ConsoleColor.White )
    { newColor = ConsoleColor.DarkBlue; }
    return newColor;
}


void Setup ( DataProviderEnum provider)
{
    //  Get a specific connection.
    IDbConnection myConnection = GetConnection ( provider );
    Console.WriteLine ($"Your connection is a {myConnection?.GetType ().Name ?? "unrecognized type"}.");
    //  Open, use and close connection ...
}

//  Returns a specific connection object OR NULL
IDbConnection GetConnection ( DataProviderEnum dataProvider )
    => dataProvider switch
    {
        DataProviderEnum.SqlServer => new SqlConnection (),
#if PC
        //Not supported on macOS
        DataProviderEnum.OleDb => new OleDbConnection (),
#endif
        DataProviderEnum.Odbc => new OdbcConnection (),
        _ => null,
    };


#endregion Methods



