
use LibraryAutomationDB

-- Emanet kitaplar tablosunda Ekleme islemi gerceklesince ne kadar kitap verildiyse o kadar stok azaltma islemi
Create Trigger ReduceStock
on DepositBooks after insert as

begin
declare @bookId int
declare @stockCount int

select @bookId=BookId, @stockCount=BookCount from inserted
update Books set StockCount=StockCount-@stockCount Where Id=@bookId

end