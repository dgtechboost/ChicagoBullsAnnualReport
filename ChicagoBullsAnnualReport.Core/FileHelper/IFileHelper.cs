using System.Collections.Generic;

namespace ChicagoBullsAnnualReport.Core
{
    public interface IFileHelper
    {
        List<List<string>> ExtractContent();
    }
}
