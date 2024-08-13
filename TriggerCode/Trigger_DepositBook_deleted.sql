

-- Emanet kitaplar tablosunda Silme islemi gerceklesince ne kadar kitap verildiyse o kadar stok arttirma islemi
Create Trigger AddStock
on DepositBooks after delete as

begin
declare @bookId int
declare @stockCount int

select @bookId=BookId, @stockCount=BookCount from deleted
update Books set StockCount=StockCount+@stockCount Where Id=@bookId

end