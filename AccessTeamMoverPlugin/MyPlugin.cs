using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace AccessTeamTemplateMoverPlugin
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Access Team Template Mover"),
        ExportMetadata("Description", "Move access team templates across different environments. The plugin handles different object type code."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAB4AAAAeCAQAAACROWYpAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAAAmJLR0QAAKqNIzIAAAAJcEhZcwAADdcAAA3XAUIom3gAAAAHdElNRQfjAhkBKzvNbPaDAAABnklEQVQ4y9WUzStEURiHH9egaTKjrCiUz79AKTIy+ZjYyFKpWSkrK9YsJnZkoUmKpsxkpSyslBmUMikLYYSGhbLQUEjDHIsZXefee+buyHsW997fe5639/zOORf+KooM3604iSvmluGjmRdiJM1JJ7N8EFCgfdwiEAiyRHHLyQ7OEQgF7COTR3Njn5Lvtt3MMZZ/j3EhYQmW0big0VBunCWAflJSVXlEgTYLPQ4a82xTa2NrvYXWABpBwrZ7ki6kDXBXsG0PryZ9Qa/jIUS2gNszBjRNjTyhk6QSLmb1B/pIV07UI8UKDh44sYAFmxyikeGSMKOcWpvjsLXvn4VpQVr+WUWQPY6J4FfCI4QoN8vdpH9sxJq0B3oEENzQK4t1PBmOwLQSFgg2qNTFRdPRe8UNRJVH9p7hb/jMIu0vCAsEW1RrgMeixQpb7weZ1IBri9SVDXrPEBMOYJ12QypJAtjhSVJb8AIgCDHFc04s5UBaTSZ3ZxRuX+GTZTeR/G0WpOhRtBrgkxAuXdB/+k14cXHOLu8KuJM3jmyN/JX4Ao6x4IJAxEnsAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE5LTAyLTI1VDAwOjQzOjU5KzAxOjAwMOmyfAAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOS0wMi0yNVQwMDo0Mzo1OSswMTowMEG0CsAAAAAZdEVYdFNvZnR3YXJlAHd3dy5pbmtzY2FwZS5vcmeb7jwaAAAAAElFTkSuQmCC"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAQAAAAAYLlVAAAABGdBTUEAALGPC/xhBQAAACBjSFJNAAB6JgAAgIQAAPoAAACA6AAAdTAAAOpgAAA6mAAAF3CculE8AAAAAmJLR0QAAKqNIzIAAAAJcEhZcwAADsQAAA7EAZUrDhsAAAAHdElNRQfjAhkBLCwB/uWDAAADhElEQVRo3u2ZWUgVURjHf5qW2mKQpmW0SAstKKVJGkRBQQ8VRJRvBS03wnqJUiIko03yIdooi4rqJdqIjAqDLIOiDB9MklZMLbXVbou7p4e5V+duM+fMnV7k/udlmPt93/93Zu4953xzIaSQzDX4fxYPM41Yyg6yLNePYxHJJOCkiSdUItTSE7mKoNaieRb36ELojjpyiZYvsJKvCIsA0Vz0sNZDZMoUGE9pb4o6QBwVAewFgjayjdPDcPBLl6AKEMl9A3uBoIP5gdMn8sArXBXggIm9QNDIUPdoPdlzyWeQV0EnJ0xNy7ntOkviNTESmHvJ976UYvjkjI8ipfELBC0MBAh3pUVRQAXpijfbn5ZLxsWyoA8gi0p2aURBKp4p0rHzNIAYCilnqg3mAEmqsREcwmGTOUCsQuxw7Q5sZBXfbAP4ohDbrAHAFaZzxSaABnqkY+vdANDMKpbx0QYAJ0+lY0v7AABKmMEp1eXSj65Lj78CfPcDiylmrNe1L+SYlntFletsCG9IlABwcNr/BzEU0h3UWrBeYh6sJMKoRBY1QQDASRP7rySblYiigA7LAJGcM7CvZ6ZcmVSeW94RwWZ++LUvkfqGuBRBHm2W94Qj2MdrnfVvrvluRMx3xRPJZ41FBC1/AqP4SRNVtAZRJ6SQQuq3GuD3agzppJNBAuF8D6L6JV4qbdIAWMgN/ugm0LfsJ84iQC0dFKps90dzN0AXs8UigEBQxWy58DQ+Giyi54i0CCDo5LD5i57xfDbZRpy1DKA9ygVGoZFUSWyk1gYBIOih2N2U98m9HOdwTKLgZybhdJ2nSHSBx4n3ulLHRu76BobTINlUb+3NKbLcyl/W/6q0vmCOdFO5QvEh+NNKqlntCbBQOnmO71O0oATOU6INWgMYJ50azhgbAACWUI2DMK09UJnpRlJjE8JwiknTAFoU0oJZGzwlOM02DUClL/5kk/07NlDm/g48kk6rtuVlRhdHSKUMcLWI93EyTCr1pg32L1inteZ9AO0cZadEaqvulWUZ3abxm3yG1c4eDtLpGzqMJok5bLfiWGu98h8zLXDwXNpM7MuV3yTqAf6SF2D/1atsQ4SnjFC01wM8ZLJMQqbPTXMvpGeIUrZ3A7TgkGiCXYpiOx88zDu5Q4YFczfALePJ2z/ZLDJJJJZG3nMviLnvGce4YDnbBv3XP/xC6i/6Bza7UOulITpkAAAAJXRFWHRkYXRlOmNyZWF0ZQAyMDE5LTAyLTI1VDAwOjQ0OjQ0KzAxOjAwf0jIWwAAACV0RVh0ZGF0ZTptb2RpZnkAMjAxOS0wMi0yNVQwMDo0NDo0NCswMTowMA4VcOcAAAAZdEVYdFNvZnR3YXJlAHd3dy5pbmtzY2FwZS5vcmeb7jwaAAAAAElFTkSuQmCC"),
        ExportMetadata("BackgroundColor", "Lavender"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Gray")]
    public class MyPlugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MyPluginControl();
        }
    }
}