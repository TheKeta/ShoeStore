using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
using ShoeStore.Presentation.Mappers;
using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Presentation.Controllers
{
    public class AdminController : Controller
    {
        private IItemService _itemService;
        private IStoreService _storeService;
        private IStoreItemService _siService;
        private IAveableSizeService _asService;
        private Configuration.Configurations _itemConfig;
        private ItemMapper _itemMapper;
        private StoreMapper _storeMapper;

        public AdminController()
        {
            _itemConfig = new Configuration.Configurations();
            _itemService = _itemConfig.GetItemService();
            _itemMapper = new ItemMapper(_itemConfig);
            _storeService = _itemConfig.GetStoreService();
            _storeMapper = new StoreMapper(_itemConfig);
            _siService = _itemConfig.GetStoreItemService();
            _asService = _itemConfig.GetAveableSizeService();
        }

        public ActionResult Index()
        {

            NewItemVM ni = new NewItemVM();
            ni.AllItems = _itemService.GetAll();
            return View(ni);
        }

        public ActionResult Stores()
        {
            NewStoreVM ns = new NewStoreVM();
            ns.AllStores = _storeService.GetAll();
            return View(ns);
        }

        public ActionResult Store(Guid id)
        {
            Store s = _storeService.FindById(id);
            NewStoreVM ns = new NewStoreVM();
            ns.ItemToAdd = new ItemVM();
            ns.Store = _storeMapper.FindItemsForStore(s);
            return View(ns);
        }

        [HttpPost]
        public ActionResult Store(NewStoreVM ns)
        {

            if (Request.Form["add"] != null)
            {
                //Add form
                if (Validate(ns))
                {
                    StoreItem si = new StoreItem();
                    si.ItemId = ns.ItemToAdd.Id;
                    si.StoreId = ns.Store.Id;
                    si.Price = ns.ItemToAdd.Price;
                    si = _siService.Add(si);
                    AveableSize ass = new AveableSize();
                    ass.SIId = si.Id;
                    ass.Size = ns.ItemToAdd.SelectedAverableSize.Size;
                    _asService.Add(ass);
                    return Redirect("/Admin/Store/" + ns.Store.Id.ToString());
                }
            }
            else if (Request.Form["remove"] != null)
            {
                if (Validate(ns))
                {
                    //remove size from item
                    StoreItem si = _siService.FindByStoreIdAndItemId(ns.Store.Id, ns.ItemToAdd.Id);
                    if (si != null)
                    {
                        _asService.RemoveBySIIdAndSize(si.Id, ns.ItemToAdd.SelectedAverableSize.Size);
                        return Redirect("/Admin/Store/" + ns.Store.Id.ToString());
                    }
                }
            }
            return Redirect("/Admin/Store/" + ns.Store.Id.ToString());
        }


        private bool Validate(NewStoreVM ns)
        {
            if (ns.ItemToAdd == null || ns.ItemToAdd.Id.Equals(new Guid()))
            {
                return false;
            }
            if (ns.Store == null || ns.Store.Id.Equals(new Guid()))
            {
                return false;
            }
            if (ns.ItemToAdd.SelectedAverableSize == null || ns.ItemToAdd.SelectedAverableSize.Size <= 0)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public ActionResult Stores(StoreVM store)
        {
            _storeService.Add(_storeMapper.ConvertFromStoreVM(store));
            return Redirect("Stores");
        }

        [HttpPost]
        public ActionResult Index(ItemVM item)
        {
            _itemService.Add(_itemMapper.ConvertFromVM(item));
            return Redirect("/Admin");
        }

        [HttpPost]
        public ActionResult Edit(ItemVM item)
        {
            _itemService.Update(_itemMapper.ConvertFromVM(item));
            return Redirect("/Admin");
        }

        public ActionResult Edit(Guid id)
        {
            NewItemVM ni = new NewItemVM();
            ni.AllItems = _itemService.GetAll();
            ni.Item = _itemMapper.ConvertToVM(_itemService.FindById(id),0,"",new Guid());
            return View("Index", ni);
        }

        public ActionResult Remove(Guid id)
        {
            _siService.RemoveByItemId(id);
            _itemService.Remove(id);
            return Redirect("/Admin");
        }

        [HttpPost]
        public ActionResult EditS(StoreVM store)
        {
            _storeService.Update(_storeMapper.ConvertFromStoreVM(store));
            return Redirect("/Admin/Stores");
        }

        public ActionResult EditS(Guid id)
        {
            NewStoreVM ni = new NewStoreVM();
            ni.AllStores = _storeService.GetAll();
            ni.Store = _storeMapper.ConvertToStoreVM(_storeService.FindById(id),null);
            return View("Stores", ni);
        }

        public ActionResult RemoveS(Guid id)
        {
            _siService.RemoveByStoreId(id);
            _storeService.Remove(id);
            return Redirect("/Admin/Stores");
        }

        public ActionResult RemoveItemFromStore(Guid storeId, Guid itemId)
        {
            _siService.RemoveByStoreIdAndItemId(storeId, itemId);
            return Redirect("/Admin/Store/" + storeId.ToString());
        }
    }
}