using Microsoft.Xrm.Sdk;

namespace AccessTeamTemplateMoverPlugin.Interface
{
    internal interface ICommand
    {
        string OrganisationUrl { get; set; }
        ILogWriter LogWriter { get; set; }
        string FileName { get; set; }
        IOrganizationService Service { get; set; }
        bool IsZipFile { get; set; }
        void Execute();
    }
}
