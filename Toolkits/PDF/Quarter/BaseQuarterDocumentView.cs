using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolkits.PDF.Quarter;

public abstract class BaseQuarterDocumentView : Core.BaseDocumentView
{
    public override void OnInitialized()
    {
        this.GridColumns = 2;
        this.GridRows = 2;
    }
}
