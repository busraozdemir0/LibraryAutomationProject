

-- Emanet kitaplar tablosunda Guncelleme islemi gerceklesince onceki stok sayisi silinip yerine yeni stogu ekleme islemi olacak
Create Trigger UpdateStock
on DepositBooks after update as

begin

declare @bookId int
declare @stockCount int 
declare @newStock int 

select @bookId=BookId, @stockCount=BookCount from deleted  -- guncelleme islemi old icin once eski stok adedi silinecek
select @bookId=BookId, @newStock=BookCount from inserted  -- ardindan yeni girilen stok adedi kaydedilecek

update Books set StockCount=StockCount-(@newStock-@stockCount) Where Id=@bookId

end