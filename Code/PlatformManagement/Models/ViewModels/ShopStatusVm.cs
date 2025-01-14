using System.ComponentModel.DataAnnotations;

namespace PlatformManagement.Models.ViewModels
{
	public class ShopStatusVm
	{
		[Display(Name = "商店ID")]
		public int Id { get; set; }
		[Display(Name = "商店頭像")]
		public string Avatar { get; set; }
		[Display(Name = "商店名")]
		public string Name { get; set; }
		[Display(Name = "商店狀態")]
		public short Status { get; set; }
	}
}
