# RagnaBot

A multi featured Ragnarok Discord bot for Arcadia.

# Commands

```
/mvp <mvp-key> 11:26
/mvp <mvp-key> 1126
/mvp <mvp-key> 5m
/market add <item-id> <maximum-price>
/market remove <item-id>
/market list
/vendor add <vendor-name>
/vendor remove <vendor-name>
/vendor list
/timetag timezone iso_datetime
```

# Wishlist

- Isolate MVP timers and channel configs per Discord server so it can be installed on different discords.
- Switch to a mongodb container.
- Add a time series DB to store the market api data for later use.
- Improve /timezone parsing of timezone and datetime
- Add a user config for timezone preference so he can skip it in the future
