using crud.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers;


[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{

    public static List<ItemModel> items = new()
    {
        new ItemModel { Id = 1, Title = "title", Description = "Description" },
        new ItemModel { Id = 2, Title = "title2", Description = "Description2" },
    };

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(items);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetItemById(int id)
    {
        var item = items.Find(x => x.Id == id);
        if (item == null)
        {
            return NotFound("Item not found");
        }

        return Ok(item);
    }

    [HttpPost]
    public IActionResult CreateItem(ItemModel Item)
    {
        items.Add(Item);
        return Ok(items);
    }

    [HttpPut]
    public IActionResult UpdateItem(ItemModel Item)
    {
        var item = items.Find(x => x.Id == Item.Id);
        if (item == null)
        {
            return NotFound("Invalid item");
        }

        item.Title = Item.Title;
        item.Description = Item.Description;
        return Ok(item);
    }

    [HttpDelete]
    public IActionResult DeleteItem(int id)
    {
        var item = items.Find(x => x.Id == id);
        if (item == null)
        {
            return NotFound("Invalid item");
        }

        items.Remove(item);
        return Ok(items);
    }

}