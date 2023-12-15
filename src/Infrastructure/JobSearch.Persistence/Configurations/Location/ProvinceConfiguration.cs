using JobSearch.Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Persistence.Configurations.Location;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    private EntityTypeBuilder<Province> _builder;

    public void Configure(EntityTypeBuilder<Province> builder)
    {
        _builder = builder;

        ConfigureRelationships();

        // Name
        _builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        SeedData();
    }

    private void ConfigureRelationships()
    {
        // Has One Country
        _builder.HasOne(province => province.Country)
            .WithMany(country => country.Provinces)
            .HasForeignKey(province => province.CountryId);

        // Has Many Addresses
        _builder.HasMany(province => province.Addresses)
            .WithOne(address => address.Province)
            .HasForeignKey(address => address.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void SeedData()
    {
        Guid turkeyId = Guid.Parse("FBAA76DA-0F6B-46C7-930F-586E3BBA2CF8");
        var provinces = new string[]
        {
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Aksaray",
            "Amasya",
            "Ankara",
            "Antalya",
            "Ardahan",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bartın",
            "Batman",
            "Bayburt",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Düzce",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkâri",
            "Hatay",
            "Iğdır",
            "Isparta",
            "İstanbul",
            "İzmir",
            "Kahramanmaraş",
            "Karabük",
            "Karaman",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kilis",
            "Kırıkkale",
            "Kırklareli",
            "Kırşehir",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Mardin",
            "Mersin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Osmaniye",
            "Rize",
            "Sakarya",
            "Samsun",
            "Şanlıurfa",
            "Siirt",
            "Sinop",
            "Sivas",
            "Şırnak",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Uşak",
            "Van",
            "Yalova",
            "Yozgat",
            "Zonguldak"
        };

        var data = new List<Province>();
        foreach (var province in provinces)
        {
            data.Add(new Province()
            {
                CountryId = turkeyId,
                Name = province
            });
        }

        _builder.HasData(data);
    }
}