using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebImmobilier.Models
{
    public class ImmobilierInitializer : DropCreateDatabaseIfModelChanges <ImmobilierContext>
    {
        
    }
}