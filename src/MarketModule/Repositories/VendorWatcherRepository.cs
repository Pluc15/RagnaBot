using System;
using System.Collections.Immutable;
using System.Linq;

public class VendorWatcherRepository(Database db)
{
    public ImmutableList<VendorWatcher> GetAllVendorWatchers()
    {
        return db.Data.VendorWatchers.ToImmutableList();
    }

    public ImmutableList<VendorWatcher> GetForUser(ulong id)
    {
        return db.Data.VendorWatchers.Where(w => w.UserId == id).ToImmutableList();
    }

    public VendorWatcher AddOrReplace(
        ulong userId,
        string vendorName
    )
    {
        var existingWatcher = db.Data.VendorWatchers.SingleOrDefault(w => w.UserId == userId && w.VendorName == vendorName);
        if (existingWatcher != null)
            return existingWatcher;

        var watcher = new VendorWatcher { UserId = userId, VendorName = vendorName };
        db.Data.VendorWatchers.Add(watcher);
        db.Dirty = true;
        return watcher;
    }

    public VendorWatcher UpdateLastKnownState(VendorWatcher watcher, Shop? shop)
    {
        db.Data.VendorWatchers.Remove(watcher);
        var updatedWatcher = watcher with { LastKnownShop = shop };
        db.Data.VendorWatchers.Add(updatedWatcher);
        db.Dirty = true;
        return updatedWatcher;
    }

    public int Delete(
        ulong userId,
        string vendorName
    )
    {
        var toRemove = db.Data.VendorWatchers.Where(w => w.UserId == userId && w.VendorName.Equals(vendorName, StringComparison.OrdinalIgnoreCase)).ToList();

        foreach (var watcher in toRemove)
            db.Data.VendorWatchers.Remove(watcher);

        if (toRemove.Count > 0)
            db.Dirty = true;

        return toRemove.Count;
    }
}