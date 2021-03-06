﻿#Greg's Stop Loss Kata

Kata description from [Github gist here](https://gist.githubusercontent.com/gregoryyoung/1500720/raw/97e9c9e29db2ad499cb9c14696bc5dea625926f7/gistfile1.txt)

Testing is very hard when time is involved ...

A trailing stop loss is a term used in financial trading. 
For a very in depth explanation you can read [here](http://www.investopedia.com/articles/trading/03/080603.asp) and [here](http://en.wikipedia.org/wiki/Order_(exchange)#Stop_orders)

However we do not need a huge amount of background 
in order to do the kata as we are going to limit the problem a bit.

The general idea is that when you buy into a stock at a price 
say $10. You want it to automatically get sold if the stock 
goes below $9 (-$1). 

If we use the term "trailing" that means that id the price goes up 
to $11 then the sell point becomes $10.

The kata is to create something that implements a trailing stop loss and to do it with TDD. To make matters more fun a price point should only move up if its held for more than 15 seconds and the stop loss should only be triggered if the price point is held for more than 30 seconds.

You will receive a "PriceChanged" message every time the price changes. Just implement it as a method that receives that message (assume later you will hook it up into something that provides that)

It will be fun to write the tests no? keep reading down for hints ....... 

For more fun... Can you do it without holding any state except for an integer variable? What trade offs would you have to make?