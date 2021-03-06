﻿// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Model.WorkFlowArchives
// Assembly: RoadFlow.Data.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B924143B-AEC1-4AFA-B627-1D84458A850C
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Model.dll

using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
  [Serializable]
  public class WorkFlowArchives
  {
    [DisplayName("ID")]
    public Guid ID { get; set; }

    [DisplayName("流程ID")]
    public Guid FlowID { get; set; }

    [DisplayName("步骤ID")]
    public Guid StepID { get; set; }

    [DisplayName("流程名称")]
    public string FlowName { get; set; }

    [DisplayName("步骤名称")]
    public string StepName { get; set; }

    [DisplayName("任务ID")]
    public Guid TaskID { get; set; }

    [DisplayName("组")]
    public Guid GroupID { get; set; }

    [DisplayName("实例ID")]
    public string InstanceID { get; set; }

    [DisplayName("标题")]
    public string Title { get; set; }

    [DisplayName("内容")]
    public string Contents { get; set; }

    [DisplayName("意见内容")]
    public string Comments { get; set; }

    [DisplayName("写入时间")]
    public DateTime WriteTime { get; set; }
  }
}
