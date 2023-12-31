using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Authorization;
using HealthyFoodWeb.Models.WikiMcModels;
using Data.Interface.Models.WikiMc;

namespace HealthyFoodWeb.Controllers
{
	public class WikiController : Controller
	{
		private IWikiBAAPageServices _blockInformationServices;

		private IWikiMcService _wikiMCImgService;

		public WikiController(IWikiBAAPageServices blockInformationServices, IWikiMcService wikiMCImgService)
		{
			_blockInformationServices = blockInformationServices;
			_wikiMCImgService = wikiMCImgService;
		}

		public IActionResult Main()
		{
			//step 1
			return View();
		}

		[HttpGet]
		public IActionResult BiologicallyActiveAdditives()
		{
			var pageViewModels = _blockInformationServices
				.GetBlocksWithAuthorAndComments();
			return View(pageViewModels);
		}

		[HttpGet]
		public IActionResult MacronutrientCalculator()
		{
			var viewModel = new WikiMcImgViewModel();

			viewModel.ImgByYear = _wikiMCImgService
				.GetAllImgByYear()
				.Select(BuildWikiMcViewModelFromDbModel)
				.ToList();
			viewModel.CalculationResult = new WikiCalculationResultViewModel();
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult MacronutrientCalculator(WikiMcImgViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				viewModel.ImgByYear = _wikiMCImgService
				.GetAllImgByYear()
				.Select(BuildWikiMcViewModelFromDbModel)
				.ToList();
				return View(viewModel);
			}
			viewModel.ImgByYear = _wikiMCImgService
				.GetAllImgByYear()
				.Select(BuildWikiMcViewModelFromDbModel)
				.ToList();
			viewModel.CalculationResult = _wikiMCImgService.GetViewModelForCaloriesCalculation(viewModel.Age, viewModel.Weight,viewModel.Height, viewModel.Percent,viewModel.Sex, viewModel.Goal, viewModel.ActivityRatio,viewModel.PercentOfProteins, viewModel.PercentOfFats, viewModel.PercentOfCarbs);
			return View(viewModel);
		}

		[HttpGet]
		public IActionResult CreateBlockInformatoin(int countImg)
		{
			BLockPageBaaViewModel block = new BLockPageBaaViewModel();
			block.CountImg = countImg;
			return View(block);
		}

		[HttpPost]
		public IActionResult CreateBlockInformatoin(BLockPageBaaViewModel block)
		{
			_blockInformationServices.CreateBlock(block);
			return RedirectToAction("BiologicallyActiveAdditives");
		}

		public IActionResult CountImg(int countImg)
		{
			return RedirectToAction("CreateBlockInformatoin", new { countImg });
		}

		[HttpPost]
		public IActionResult BiologicallyActiveAdditives(string newComment, int blockId, int commentId)
		{
			_blockInformationServices.CreateComment(blockId, newComment);
			return RedirectToAction("BiologicallyActiveAdditives");
		}

        [HttpPost]
        [Authorize]
		public IActionResult Remove(int blockId)
		{
			_blockInformationServices.RemoveBlock(blockId);
			return RedirectToAction("BiologicallyActiveAdditives");
		}

		[Authorize]
		public IActionResult RemoveComment(int commentId)
		{
			_blockInformationServices.RemoveComment(commentId);
			return RedirectToAction("BiologicallyActiveAdditives");
		}

		[HttpGet]
		[Authorize]
		public IActionResult UpdateComment(int Id)
		{
			var viewModel = _blockInformationServices.GetBlockCommentPageBaaViewModel(Id);
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult UpdateComment(BLockPageBaaViewModel blockViewModel)
		{

			_blockInformationServices.UpdateBlockComment(blockViewModel.Id, blockViewModel.Text);
			return RedirectToAction("BiologicallyActiveAdditives");
		}

		[HttpGet]
		[Authorize]
		public IActionResult UpdateBlock(int id)
		{
			var viewModel = _blockInformationServices.GetBLockPageBaaViewModel(id);
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult UpdateBlock(BLockPageBaaViewModel blockViewModel)
		{
			_blockInformationServices.Updateblock(blockViewModel.Id, blockViewModel.Title, blockViewModel.Text);
			return RedirectToAction("BiologicallyActiveAdditives");
		}

		[HttpGet]
		[Authorize]
		public IActionResult AddImg()
		{
			return View();
		}

		[HttpPost]
		[Authorize]
		public IActionResult AddImg(WikiMcViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			_wikiMCImgService.AddImg(viewModel);
			return RedirectToAction("ShowUploadedImages");
		}

		[HttpGet]
		[Authorize]
		public IActionResult ShowUploadedImages(int page = 1, int perPage = 4)
		{
			var viewModel = _wikiMCImgService.GetShowUploadedImagesViewModel(page, perPage);
			return View(viewModel);
		}

		public IActionResult DeleteImage(int imgId)
		{
			_wikiMCImgService.DeleteImage(imgId);
			return RedirectToAction("ShowUploadedImages");
		}

		[HttpGet]
		public IActionResult UpdateImage(int id)
		{
			var viewModel = _wikiMCImgService.GetImageViewModel(id);
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult UpdateImage(WikiMcViewModel wikiMcViewModel)
		{
			_wikiMCImgService.UpdateAllEx�eptTags(
				wikiMcViewModel.Id,
				wikiMcViewModel.ImgType,
				wikiMcViewModel.ImgUrl,
				wikiMcViewModel.Year);

			_wikiMCImgService.UpdateTags(
				wikiMcViewModel.Id,
				wikiMcViewModel.UserTagsForImage);

			return RedirectToAction("ShowUploadedImages", "Wiki");
		}

		private WikiMcViewModel BuildWikiMcViewModelFromDbModel(WikiMcImage x)
		{
			return new WikiMcViewModel
			{
				Id = x.Id,
				Year = x.Year,
				ImgUrl = x.ImgUrl,
				ImgType = x.ImgType,
				UserTagsForImage = x.Tags?.Select(x => x.TagName).ToList() ?? new List<string>()
			};
		}
	}
}