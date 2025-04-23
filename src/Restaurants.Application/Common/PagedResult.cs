namespace Restaurants.API.Common;

public class PagedResult<t>
{


    public PagedResult( IEnumerable<t> items ,int count,int pageSize, int pageNumber)
    {
        Items = items;
        TotalItemsCount = count;
        TotalPages =(int) Math.Ceiling(TotalItemsCount / (double)pageSize);
        ItemsFrom = pageSize * (pageNumber - 1) + 1;
        ItemsTo = ItemsFrom + (pageSize - 1);

    }


    public  IEnumerable<t> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount{ get; set; }
    public int ItemsFrom{ get; set; }
    public int ItemsTo{ get; set; }

}
