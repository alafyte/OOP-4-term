create procedure PROC_COUNT_SATELLITES
as 
begin 
declare @k int = (select count (*) from dbo.SATELLITES)
select @k[NumOfSatellites];
return @k;
end;