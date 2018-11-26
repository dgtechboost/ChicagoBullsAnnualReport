using System.Collections.Generic;

namespace ChicagoBullsAnnualReport.Core
{
    public interface IReportHelper : IContentMapper
    {
        List<Dictionary<string, string>> ContentProcessor(List<List<string>> list);
    }
}
