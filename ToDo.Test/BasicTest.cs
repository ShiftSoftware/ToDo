﻿using ShiftSoftware.ShiftEntity.Model.Dtos;
using ShiftSoftware.ShiftEntity.Model;
using System.Text.Json.Nodes;
using System.Text;
using Xunit.Abstractions;

namespace ToDo.Test;

public class BasicTest<DTO, ListDTO>
    where DTO : ShiftEntityDTO
    where ListDTO : ShiftEntityListDTO
{
    public HttpClient client;
    public ITestOutputHelper output;

    public string ApiItemName { get; set; }
    public string OdataItemName { get; set; }

    public BasicTest(string apiItemName, string odataItemItem, HttpClient client, ITestOutputHelper output)
    {
        this.ApiItemName = apiItemName;
        this.OdataItemName = odataItemItem;

        this.client = client;
        this.output = output;
    }

    public async Task<DTO> Get(long ID, bool ensureSuccessStatusCode = true)
    {
        HttpResponseMessage obj = await client.GetAsync($"/api/{ApiItemName}/{ID}");

        var text = await obj.Content.ReadAsStringAsync();

        if (ensureSuccessStatusCode)
            obj.EnsureSuccessStatusCode();

        var item = JsonNode.Parse(text).Deserialize<ShiftEntityResponse<DTO>>();

        return item!.Entity!;
    }

    public async Task<DTO> Post(DTO dto, bool ensureSuccessStatusCode = true)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

        HttpResponseMessage obj = await client.PostAsync($"/api/{ApiItemName}", httpContent);

        var text = await obj.Content.ReadAsStringAsync();

        if (ensureSuccessStatusCode)
            obj.EnsureSuccessStatusCode();

        var item = JsonNode.Parse(text).Deserialize<ShiftEntityResponse<DTO>>();

        return item!.Entity!;
    }

    public async Task<DTO> Put(long ID, DTO dto, bool ensureSuccessStatusCode = true)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

        HttpResponseMessage obj = await client.PutAsync($"/api/{ApiItemName}/{ID}", httpContent);

        var text = await obj.Content.ReadAsStringAsync();

        if (ensureSuccessStatusCode)
            obj.EnsureSuccessStatusCode();

        var item = JsonNode.Parse(text).Deserialize<ShiftEntityResponse<DTO>>();

        return item!.Entity!;
    }

    public async Task<DTO> Delete(long ID, bool ensureSuccessStatusCode = true)
    {
        HttpResponseMessage obj = await client.DeleteAsync($"/api/{ApiItemName}/{ID}");

        var text = await obj.Content.ReadAsStringAsync();

        if (ensureSuccessStatusCode)
            obj.EnsureSuccessStatusCode();

        var item = JsonNode.Parse(text).Deserialize<ShiftEntityResponse<DTO>>();

        return item!.Entity!;
    }

    public async Task<List<ListDTO>> OdataList(string? queryString = null, bool ensureSuccessStatusCode = true)
    {
        HttpResponseMessage obj = await client.GetAsync($"/odata/{OdataItemName}{queryString}");

        if (ensureSuccessStatusCode)
            obj.EnsureSuccessStatusCode();

        var text = await obj.Content.ReadAsStringAsync();

        var items = JsonNode.Parse(text)!["value"].Deserialize<List<ListDTO>>();

        return items!;
    }

    public async Task<List<RevisionDTO>> RevisionList(long ID, bool ensureSuccessStatusCode = true)
    {
        HttpResponseMessage obj = await client.GetAsync($"/odata/{OdataItemName}/{ID}/revisions");

        if (ensureSuccessStatusCode)
            obj.EnsureSuccessStatusCode();

        var text = await obj.Content.ReadAsStringAsync();

        var items = JsonNode.Parse(text)!["value"].Deserialize<List<RevisionDTO>>();

        return items!;
    }
}
