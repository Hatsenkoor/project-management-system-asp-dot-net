using PCVMS.Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCVM.Web.Helpers
{
    public class State
    {
        public string Name { get; set; }
        public string VisibleName { get; set; }
        public string SchemeCode { get; set; }
    }
    public class Transition
    {
        public string ProcessId { get; set; }
        public object ActorIdentityId { get; set; }
        public object ExecutorIdentityId { get; set; }
        public string FromActivityName { get; set; }
        public string FromStateName { get; set; }
        public bool IsFinalised { get; set; }
        public string ToActivityName { get; set; }
        public string ToStateName { get; set; }
        public string TransitionClassifier { get; set; }
        public DateTime TransitionTime { get; set; }
        public string TriggerName { get; set; }
    }
    public class ClassHistory
    {


        public string Id { get; set; }
        public string StateName { get; set; }
        public string IdentityId { get; set; }
        public string ActivityName { get; set; }
        public string SchemeId { get; set; }
        public string SchemeCode { get; set; }
        public string PreviousState { get; set; }
        public object PreviousStateForDirect { get; set; }
        public object PreviousStateForReverse { get; set; }
        public string PreviousActivity { get; set; }
        public object PreviousActivityForDirect { get; set; }
        public object PreviousActivityForReverse { get; set; }
        public object ParentProcessId { get; set; }
        public string RootProcessId { get; set; }
        public bool IsDeterminingParametersChanged { get; set; }
        public int InstanceStatus { get; set; }
        public bool IsSubProcess { get; set; }
        public object TenantId { get; set; }
        public List<DocumentTransitionHistory> History { get; set; }
        public object SubProcessIds { get; set; }
        public List<Transition> Transitions { get; set; }
    }
    public class MainResponse<T>
    {
        public List<T> data { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public string message { get; set; }
    }
    public class SingleResponse<T>
    {
        public T data { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public string message { get; set; }
    }
    class classCreateSchime
    {
        public string schemeCode { get; set; }
        public string identityId { get; set; }

    }
    public class Command
    {
        public string CommandName { get; set; }
        public string LocalizedName { get; set; }
        public string ValidForActivityName { get; set; }
        public string ValidForStateName { get; set; }
        //public OptimaJet.Workflow.Core.Model.TransitionClassifier Classifier { get; set; }
        public List<object> Identities { get; set; }
        public string ProcessId { get; set; }
        public bool IsForSubprocess { get; set; }
        public List<object> Parameters { get; set; }
    }


    public class ProcessInstance
    {
        public string Id { get; set; }
        public string StateName { get; set; }
        public string ActivityName { get; set; }
        public string SchemeId { get; set; }
        public string SchemeCode { get; set; }
        public string PreviousState { get; set; }
        public object PreviousStateForDirect { get; set; }
        public object PreviousStateForReverse { get; set; }
        public string PreviousActivity { get; set; }
        public object PreviousActivityForDirect { get; set; }
        public object PreviousActivityForReverse { get; set; }
        public object ParentProcessId { get; set; }
        public string RootProcessId { get; set; }
        public bool IsDeterminingParametersChanged { get; set; }
        public int InstanceStatus { get; set; }
        public bool IsSubProcess { get; set; }
        public object TenantId { get; set; }
        public object Transitions { get; set; }
        public object History { get; set; }
       
        public object SubProcessIds { get; set; }
    }

    public class Data
    {
        public bool WasExecuted { get; set; }
        public ProcessInstance ProcessInstance { get; set; }
    }
}
