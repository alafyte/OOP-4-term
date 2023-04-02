create procedure PROC_COUNT_PLANETS
as 
begin 
declare @k int = (select count (*) from dbo.PLANETS)
select @k[NumOfPlanets];
return @k;
end;
