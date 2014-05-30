﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HangFire.Web.Pages
{
    
    #line 2 "..\..\Pages\QueuesPage.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    
    #line 3 "..\..\Pages\QueuesPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 4 "..\..\Pages\QueuesPage.cshtml"
    using Common;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Pages\QueuesPage.cshtml"
    using HangFire.Storage;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Pages\QueuesPage.cshtml"
    using Pages;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Pages\QueuesPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class QueuesPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Pages\QueuesPage.cshtml"
  
    Layout = new LayoutPage { Title = "Queues" };

    IList<QueueWithTopEnqueuedJobsDto> queues;

    var monitor = JobStorage.Current.GetMonitoringApi();
    queues = monitor.Queues();


            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 18 "..\..\Pages\QueuesPage.cshtml"
 if (queues.Count == 0)
{

            
            #line default
            #line hidden
WriteLiteral("    <div class=\"alert alert-warning\">\r\n        No queued jobs found. Try to enque" +
"ue a job.\r\n    </div>\r\n");


            
            #line 23 "..\..\Pages\QueuesPage.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral(@"    <table class=""table table-striped"">
        <thead>
            <tr>
                <th>Queue</th>
                <th>Length</th>
                <th>Fetched</th>
                <th>Next jobs</th>
            </tr>
        </thead>
        <tbody>
");


            
            #line 36 "..\..\Pages\QueuesPage.cshtml"
             foreach (var queue in queues)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n                        <a class=" +
"\"label-queue\" href=\"");


            
            #line 40 "..\..\Pages\QueuesPage.cshtml"
                                                Write(Request.LinkTo("/queues/" + queue.Name));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 41 "..\..\Pages\QueuesPage.cshtml"
                       Write(queue.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n                    </td>\r\n                    <t" +
"d>");


            
            #line 44 "..\..\Pages\QueuesPage.cshtml"
                   Write(queue.Length);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>\r\n");


            
            #line 46 "..\..\Pages\QueuesPage.cshtml"
                         if (queue.Fetched.HasValue)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <a href=\"");


            
            #line 48 "..\..\Pages\QueuesPage.cshtml"
                                Write(Request.LinkTo("/queues/fetched/" + queue.Name));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 49 "..\..\Pages\QueuesPage.cshtml"
                           Write(queue.Fetched);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </a>\r\n");


            
            #line 51 "..\..\Pages\QueuesPage.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <em>N/A</em>\r\n");


            
            #line 55 "..\..\Pages\QueuesPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td>\r\n");


            
            #line 58 "..\..\Pages\QueuesPage.cshtml"
                         if (queue.FirstJobs.Count == 0)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <em>No jobs queued.</em>\r\n");


            
            #line 61 "..\..\Pages\QueuesPage.cshtml"
                        }
                        else
                        {

            
            #line default
            #line hidden
WriteLiteral(@"                            <table class=""table table-condensed table-bordered table-inner"">
                                <thead>
                                    <tr>
                                        <th class=""min-width"">Id</th>
                                        <th class=""min-width"">State</th>
                                        <th>Job</th>
                                        <th class=""align-right min-width"">Enqueued</th>
                                    </tr>
                                </thead>
                                <tbody>
");


            
            #line 74 "..\..\Pages\QueuesPage.cshtml"
                                     foreach (var job in queue.FirstJobs)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr class=\"");


            
            #line 76 "..\..\Pages\QueuesPage.cshtml"
                                               Write(!job.Value.InEnqueuedState ? "obsolete-data" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                            <td class=\"min-width\">\r\n         " +
"                                       <a href=\"");


            
            #line 78 "..\..\Pages\QueuesPage.cshtml"
                                                    Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 78 "..\..\Pages\QueuesPage.cshtml"
                                                                                        Write(HtmlHelper.JobId(job.Key));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");


            
            #line 79 "..\..\Pages\QueuesPage.cshtml"
                                                 if (!job.Value.InEnqueuedState)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <span title=\"Job\'s state has " +
"been changed while fetching data.\" class=\"glyphicon glyphicon-question-sign\"></s" +
"pan>\r\n");


            
            #line 82 "..\..\Pages\QueuesPage.cshtml"
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </td>\r\n                              " +
"              <td class=\"min-width\">\r\n                                          " +
"      <span class=\"label label-default\" style=\"");


            
            #line 85 "..\..\Pages\QueuesPage.cshtml"
                                                                                     Write(JobHistoryRenderer.ForegroundStateColors.ContainsKey(job.Value.State) ? String.Format("background-color: {0};", JobHistoryRenderer.ForegroundStateColors[job.Value.State]) : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                                    ");


            
            #line 86 "..\..\Pages\QueuesPage.cshtml"
                                               Write(job.Value.State);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </span>\r\n                      " +
"                      </td>\r\n                                            <td>\r\n " +
"                                               <a class=\"job-method\" href=\"");


            
            #line 90 "..\..\Pages\QueuesPage.cshtml"
                                                                       Write(Request.LinkTo("/job/" + job.Key));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                                    ");


            
            #line 91 "..\..\Pages\QueuesPage.cshtml"
                                               Write(HtmlHelper.DisplayMethod(job.Value.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                </a>\r\n                         " +
"                   </td>\r\n                                            <td class=" +
"\"align-right min-width\">\r\n");


            
            #line 95 "..\..\Pages\QueuesPage.cshtml"
                                                 if (job.Value.EnqueuedAt.HasValue)
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <span data-moment=\"");


            
            #line 97 "..\..\Pages\QueuesPage.cshtml"
                                                                  Write(JobHelper.ToStringTimestamp(job.Value.EnqueuedAt.Value));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                                        ");


            
            #line 98 "..\..\Pages\QueuesPage.cshtml"
                                                   Write(job.Value.EnqueuedAt);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                                    </span>\r\n");


            
            #line 100 "..\..\Pages\QueuesPage.cshtml"
                                                }
                                                else
                                                {

            
            #line default
            #line hidden
WriteLiteral("                                                    <em>n/a</em>\r\n");


            
            #line 104 "..\..\Pages\QueuesPage.cshtml"
                                                }

            
            #line default
            #line hidden
WriteLiteral("                                            </td>\r\n                              " +
"          </tr>\r\n");


            
            #line 107 "..\..\Pages\QueuesPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </tbody>\r\n                            </table>\r\n");


            
            #line 110 "..\..\Pages\QueuesPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n            </tr>\r\n");


            
            #line 113 "..\..\Pages\QueuesPage.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n");


            
            #line 116 "..\..\Pages\QueuesPage.cshtml"
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
