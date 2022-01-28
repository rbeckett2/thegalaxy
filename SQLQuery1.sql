
INSERT INTO dbo.datRegions ("RegionName", "GalaxyID", "IsActive") VALUES (@RegionName, @GalaxyID, @IsActive);
SELECT @@identity As 'RegionID';