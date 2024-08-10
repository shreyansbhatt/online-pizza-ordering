using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ErrorHandler
/// </summary>
public class ErrorHandler
{
    public ErrorHandler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void WriteError(Exception ex)
    {
        WriteError(ex, true);
    }

    /// <summary>
    /// WriteError()
    /// Create file in Error folder when error comes in applcation page.
    /// </summary>
    public static void WriteError(Exception ex, Boolean NotFromAPI)
    {
        try
        {
            string path = DateTime.Today.ToString("dd-MMM-yy") + ".txt";
            string errorLogFolderPath = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory) + @"ErrorLogs";
            string fileFullPath = errorLogFolderPath + @"\" + path;
            if (!Directory.Exists(errorLogFolderPath))
            {
                Directory.CreateDirectory(errorLogFolderPath);
                File.Create(fileFullPath).Close();
            }
            else
            {
                if (!File.Exists(fileFullPath))
                {
                    File.Create(fileFullPath).Close();
                }
            }


            StreamWriter w = File.AppendText(fileFullPath);

            try
            {
                StackTrace trace = new StackTrace(ex, true);

                StringBuilder err = new StringBuilder();
                err.Append("Log Entry : " + DateTime.Now.ToString(CultureInfo.InvariantCulture) + Environment.NewLine);
                err.Append("Inner Exception : " + (ex.InnerException != null ? ex.InnerException.Message : "") + Environment.NewLine);
                err.Append("File Name : " + trace.GetFrame(0).GetFileName() + Environment.NewLine);
                err.Append("Line : " + trace.GetFrame(0).GetFileLineNumber() + Environment.NewLine);
                err.Append("Column: " + trace.GetFrame(0).GetFileColumnNumber() + Environment.NewLine);
                err.Append("Error Message: " + ex.Message + Environment.NewLine);
                err.Append("Source: " + ex.Source + Environment.NewLine);
                err.Append("StackTrace: " + ex.StackTrace + Environment.NewLine);
                err.Append("TargetSite:" + Convert.ToString(ex.TargetSite));

                w.WriteLine("\r\n" + err);

                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
            catch (Exception EX)
            {
                WriteError(EX);
            }
            finally
            {
                w.Close();
            }
        }
        catch
        {
        }
    }
}