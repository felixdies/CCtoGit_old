using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCtoGit
{
  public class ClearCase
  {
    private string Fmt
    {
      get
      {
        return "'"
        + "Attributes=%a"
        + "|Comment=%Nc"
        + "|CreatedDate=%d"
        + "|EventDescription=%e"
        + "|CheckoutInfo=%Rf"
        + "|HostName=%h"
        + "|IndentLevel=%i"
        + "|Labels=%l"
        + "|ObjectKind=%m"
        + "|ElementName=%En"
        + "|Version=%Vn"
        + "|PredecessorVersion=%PVn"
        + "|Operation=%o"
        + "|Type=%[type]p"
        + "|SymbolicLink=%[slink_text]p"
        + "|OwnerLoginName=%[owner]p"
        + "|OwnerFullName=%[owner]Fp"
        + "|HyperLink=%[hlink]p"
        + "\n'";
      }
    }

  }
}
