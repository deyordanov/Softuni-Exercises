namespace Boardgames.DataProcessor.ExportDto.Creators;

using System.Xml.Serialization;

[XmlType("Creator")]
public class ExportCreatorDto
{
    [XmlAttribute(nameof(BoardgamesCount))]
    public int BoardgamesCount { get; set; }

    [XmlElement("CreatorName")]
    public string Name { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ExportBoardgameDto[] Boardgames { get; set; } = null!;
}