﻿// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.CompletedTasksController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
  public class CompletedTasksController : Controller
  {
    public ActionResult Index()
    {
      return this.Index((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(FormCollection coll)
    {
      List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
      string empty = string.Empty;
      RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
      RoadFlow.Platform.WeiXin.Organize.CheckLogin();
      Guid currentUserId = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
      string str = this.Request.QueryString["searchkey"];
      if (coll != null)
        str = this.Request.Form["SearchTitle"];
      Guid userID = currentUserId;
      long num;
      ref long local = ref num;
      int size = 15;
      int number = 1;
      string title = str;
      string flowid = "";
      string sender = "";
      string date1 = "";
      string date2 = "";
      int type = 1;
      string order = "";
      List<RoadFlow.Data.Model.WorkFlowTask> tasks = workFlowTask.GetTasks(userID, out local, size, number, title, flowid, sender, date1, date2, type, order);
      // ISSUE: reference to a compiler-generated field
      if (CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, long, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Count", typeof (CompletedTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0.Target((CallSite) CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__0, this.ViewBag, num);
      // ISSUE: reference to a compiler-generated field
      if (CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "SearchTitle", typeof (CompletedTasksController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1.Target((CallSite) CompletedTasksController.\u003C\u003Eo__1.\u003C\u003Ep__1, this.ViewBag, str);
      return (ActionResult) this.View((object) tasks);
    }

    public string GetTasks()
    {
      string str1 = this.Request.QueryString["pagenumber"];
      string str2 = this.Request.QueryString["pagesize"];
      string title = this.Request.QueryString["SearchTitle"];
      long count;
      List<RoadFlow.Data.Model.WorkFlowTask> tasks = new RoadFlow.Platform.WorkFlowTask().GetTasks(RoadFlow.Platform.WeiXin.Organize.CurrentUserID, out count, str2.ToInt(15), str1.ToInt(2), title, "", "", "", "", 1, "");
      JsonData jsonData1 = new JsonData();
      if (tasks.Count == 0)
        return "[]";
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in tasks)
      {
        JsonData jsonData2 = new JsonData();
        JsonData jsonData3 = jsonData2;
        string index1 = "id";
        Guid guid = workFlowTask.ID;
        JsonData jsonData4 = (JsonData) guid.ToString();
        jsonData3[index1] = jsonData4;
        jsonData2["title"] = (JsonData) workFlowTask.Title;
        JsonData jsonData5 = jsonData2;
        string index2 = "time";
        DateTime? completedTime1 = workFlowTask.CompletedTime1;
        string str3;
        if (!completedTime1.HasValue)
        {
          str3 = "";
        }
        else
        {
          completedTime1 = workFlowTask.CompletedTime1;
          str3 = completedTime1.Value.ToDateTimeString();
        }
        JsonData jsonData6 = (JsonData) str3;
        jsonData5[index2] = jsonData6;
        jsonData2["sender"] = (JsonData) workFlowTask.SenderName;
        JsonData jsonData7 = jsonData2;
        string index3 = "flowid";
        guid = workFlowTask.FlowID;
        JsonData jsonData8 = (JsonData) guid.ToString();
        jsonData7[index3] = jsonData8;
        JsonData jsonData9 = jsonData2;
        string index4 = "stepid";
        guid = workFlowTask.StepID;
        JsonData jsonData10 = (JsonData) guid.ToString();
        jsonData9[index4] = jsonData10;
        jsonData2["instanceid"] = (JsonData) workFlowTask.InstanceID;
        JsonData jsonData11 = jsonData2;
        string index5 = "groupid";
        guid = workFlowTask.GroupID;
        JsonData jsonData12 = (JsonData) guid.ToString();
        jsonData11[index5] = jsonData12;
        jsonData1.Add((object) jsonData2);
      }
      return jsonData1.ToJson(true);
    }
  }
}
