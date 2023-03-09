using System.Collections.Generic;

namespace WPF_MiniForms_CSharp.Models.Records
{

    internal record ComposedMail(string Header, string Body, IEnumerable<string> Receivers, IEnumerable<string> CarbonCopy, IEnumerable<string> BlindCarbonCopy);

}
