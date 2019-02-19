using Microsoft.Xrm.Sdk;

namespace AccessTeamMoverPlugin.Command
{
    internal interface ICommand
    {
        string FileName { get; set; }
        IOrganizationService Service { get; set; }
        bool IsZipFile { get; set; }
        void Execute();
    }
}
