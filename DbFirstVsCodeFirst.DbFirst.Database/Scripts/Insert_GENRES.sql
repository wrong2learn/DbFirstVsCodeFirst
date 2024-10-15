MERGE INTO [Lookup].[GENRES] AS TARGET 
  USING (VALUES 	
    (1, N'Pop'),
    (2, N'Rock'),
    (3, N'Metal'),
    (4, N'Jazz')
  )
  AS SOURCE (Id, [Name]) 
  ON TARGET.Id = SOURCE.Id
  -- update matched rows 
  WHEN MATCHED THEN 
  UPDATE SET [Name] = SOURCE.[Name]
  -- insert new rows 
  WHEN NOT MATCHED BY TARGET THEN 
  INSERT (Id, [Name]) 
  VALUES (Id, [Name]);