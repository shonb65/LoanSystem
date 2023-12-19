using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoanSystem.Repository;

public class JsonRepository<T> : IRepository<T> where T : IModel
{
    private readonly string _filePath;

    public JsonRepository(string filePath)
    {
        _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    public async Task<List<T>> GetAllAsync()
    {
        using (var streamReader = new StreamReader(_filePath))
        {
            var json = await streamReader.ReadToEndAsync();
            
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var allData = await GetAllAsync();
        return allData.Find(item => item.GetType().GetProperty("Id").GetValue(item).ToString() == id.ToString());
    }

    public async Task AddAsync(T entity)
    {
        var allData = await GetAllAsync();
        allData.Add(entity);
        await WriteDataToFile(allData);
    }

    public async Task UpdateAsync(Guid id, T updatedEntity)
    {
        var allData = await GetAllAsync();
        var existingEntity = allData.Find(item => item.GetType().GetProperty("Id").GetValue(item).ToString() == id.ToString());

        if (existingEntity != null)
        {
            allData.Remove(existingEntity);
            allData.Add(updatedEntity);
            await WriteDataToFile(allData);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var allData = await GetAllAsync();
        var entityToRemove = allData.Find(item => item.GetType().GetProperty("Id").GetValue(item).ToString() == id.ToString());

        if (entityToRemove != null)
        {
            allData.Remove(entityToRemove);
            await WriteDataToFile(allData);
        }
    }

    private async Task WriteDataToFile(List<T> data)
    {
        var json = JsonSerializer.Serialize(data);
        using (var streamWriter = new StreamWriter(_filePath, false))
        {
            await streamWriter.WriteAsync(json);
        }
    }
}
