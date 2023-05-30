using System;
namespace CMSApi.Models
{
	public class CMSDatabaseSettings
	{
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CMSCollectionName { get; set; } = null!;
    }
}

