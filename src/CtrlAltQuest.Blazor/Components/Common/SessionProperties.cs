namespace CtrlAltQuest.Blazor.Components.Common
{
    public class SessionProperties
    {
        public string AdditionalTitle { get; set; } = "hello world";
        public Action TitleChanged { get; set; }
    }
}
