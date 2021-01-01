using Microsoft.PowerBI.Api.V2.Models;
using System;

namespace BIPortalV2.Models
{
    public class TileEmbedConfig : EmbedConfig
    {
        public string dashboardId { get; set; }
    }
}