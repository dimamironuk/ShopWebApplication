using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data.Data
{
    public class ShopDbContext : DbContext //IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ShopDbContext() { }
        public ShopDbContext(DbContextOptions options) : base(options) { }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             base.OnConfiguring(optionsBuilder);
             optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YouTubeMvc;Integrated Security=True;");
         }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User { Id = 1, Nickname = "JohnDoe", Name = "John Doe", Email = "john.doe@example.com", Birthday = new DateTime(1990, 5, 15), AvatarUrl = "https://www.cnet.com/a/img/resize/20d6844768bd3f5f0df41deee97897423bcaf3c5/hub/2021/11/03/3c2a7d79-770e-4cfa-9847-66b3901fb5d7/c09.jpg?auto=webp&fit=crop&height=1200&width=1200",Password = "123456" },
                new User { Id = 2, Nickname = "JaneSmith", Name = "Jane Smith", Email = "jane.smith@example.com", Birthday = new DateTime(1985, 10, 25), AvatarUrl = "https://i.pinimg.com/236x/6f/0c/7d/6f0c7dd236a49fef3d2c7ad9def7f87c.jpg",Password = "qwerty" },
                new User { Id = 3, Nickname = "MichaelBrown", Name = "Michael Brown", Email = "michael.brown@example.com", Birthday = new DateTime(1988, 3, 8), AvatarUrl = "https://i.pinimg.com/236x/ef/31/da/ef31da3aac21d75fede9d3ca00b8f14f.jpg",Password = "221002" },
                new User { Id = 4, Nickname = "EmilyJohnson", Name = "Emily Johnson", Email = "emily.johnson@example.com", Birthday = new DateTime(1995, 7, 12), AvatarUrl = "https://i.pinimg.com/236x/5b/02/47/5b0247d140ff9659066d61fa63edc79a.jpg",Password = "school1" },
                new User { Id = 5, Nickname = "WilliamWilson", Name = "William Wilson", Email = "william.wilson@example.com", Birthday = new DateTime(1992, 9, 20), AvatarUrl = "https://i.pinimg.com/236x/28/6d/91/286d914fd4f3739e4b063aaf7875a04a.jpg",Password = "412512" },
                new User { Id = 6, Nickname = "OliviaDavis", Name = "Olivia Davis", Email = "olivia.davis@example.com", Birthday = new DateTime(1987, 12, 3), AvatarUrl = "https://i.pinimg.com/236x/b1/d8/db/b1d8dbf9167c52e0615adc13437f07bf.jpg",Password = "satq24" },
                new User { Id = 7, Nickname = "JamesMiller", Name = "James Miller", Email = "james.miller@example.com", Birthday = new DateTime(1993, 4, 18), AvatarUrl = "https://i.pinimg.com/236x/f8/32/e9/f832e9eeb044c0724ed38d11a6fc3c52.jpg",Password = "rq24ar" },
                new User { Id = 8, Nickname = "SophiaMartinez", Name = "Sophia Martinez", Email = "sophia.martinez@example.com", Birthday = new DateTime(1983, 6, 30), AvatarUrl = "https://i.pinimg.com/236x/74/a2/9b/74a29b1557ea388218519536143e3eee.jpg",Password = "52356" },
                new User { Id = 9, Nickname = "BenjaminGarcia", Name = "Benjamin Garcia", Email = "benjamin.garcia@example.com", Birthday = new DateTime(1991, 8, 7), AvatarUrl = "https://cdn-0001.qstv.on.epicgames.com/spbduGeODldQXSaWaZ/image/landscape_comp.jpeg",Password = "rEe24" },
                new User { Id = 10 Nickname = "IsabellaLopez", Name = "Isabella Lopez", Email = "isabella.lopez@example.com", Birthday = new DateTime(1989, 11, 22), AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/9/96/Meme_Man_on_transparent_background.webp/316px-Meme_Man_on_transparent_background.webp.png",Password = "rw0wrq" }
            });*/
           /* modelBuilder.Entity<Video>().HasData(new List<Video>()
            {
                new Video { Id = 1, UserId = 1, Title = "Introduction to C#", Description = "A beginner's guide to C#", DateOfPublication = new DateTime(2023, 5, 15), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://static-cse.canva.com/blob/1633154/1600w-wK95f3XNRaM.53b81e59.jpg" },
                new Video { Id = 2, UserId = 2, Title = "Advanced Java Programming", Description = "Deep dive into Java programming.", DateOfPublication = new DateTime(2023, 6, 20), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://marketplace.canva.com/EAFf5rfnPgA/1/0/1600w/canva-blue-modern-eye-catching-vlog-youtube-thumbnail-LEcp-BYepDU.jpg" },
                new Video { Id = 3, UserId = 2, Title = "JavaScript Essentials", Description = "Everything you need to know about JavaScript.", DateOfPublication = new DateTime(2023, 7, 10), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://i0.wp.com/i.pinimg.com/originals/d4/94/76/d49476e6169ae02dd0eea882b1443586.jpg?resize=160,120" },
                new Video { Id = 4, UserId = 5, Title = "Python for Data Science", Description = "Using Python for data analysis and machine learning.", DateOfPublication = new DateTime(2023, 8, 5), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/125342479/original/7b112c248eb522d29016e1cca95a7ccd9cf50d6f/design-eye-catchy-youtube-thumbnail-in-2-hours.jpg" },
                new Video { Id = 5, UserId = 1, Title = "Web Development with React", Description = "Building modern web applications with React.", DateOfPublication = new DateTime(2023, 9, 12), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSB-bmx9MFjFvH0p1MZzMU8fwYPAO-mzUhZM6di1tsXrzWfSdXyvJyr1Ry503HmyDnt8ns&usqp=CAU" },
                new Video { Id = 6, UserId = 6, Title = "Database Management with SQL", Description = "Learn how to manage databases using SQL.", DateOfPublication = new DateTime(2023, 10, 18), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/163993931/original/bea1055dbfd13392ad4d291eae22fb9cd3a84484/design-amazing-youtube-thumbnail-in-3-hours.jpg" },
                new Video { Id = 7, UserId = 7, Title = "Cybersecurity Basics", Description = "An introduction to cybersecurity principles.", DateOfPublication = new DateTime(2023, 11, 21), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/pbdwbva4-WI/maxresdefault.jpg?resize=160,120" },
                new Video { Id = 8, UserId = 8, Title = "Mobile App Development", Description = "Creating mobile applications for Android and iOS.", DateOfPublication = new DateTime(2023, 12, 8), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/eftWmNzWbxk/maxresdefault.jpg?resize=160,120" },
                new Video { Id = 9, UserId = 5, Title = "Cloud Computing with AWS", Description = "Understanding cloud computing with AWS.", DateOfPublication = new DateTime(2024, 1, 5), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/8YbZuaBP9B8/maxresdefault.jpg?resize=160,120" },
                new Video { Id = 10, UserId = 10, Title = "Artificial Intelligence and Machine Learning", Description = "Exploring AI and machine learning concepts.", DateOfPublication = new DateTime(2024, 2, 14), VideoUrl = "https://www.microsoft.com/en-us/videoplayer-nocookie/embed/RWe8JU?pid=ocpVideo1&maskLevel=20&market=en-us",PreviewUrl = "https://i0.wp.com/ytimg.googleusercontent.com/vi/CJ3hfxxlF2Q/maxresdefault.jpg?resize=160,120" }
            });*/

        }
    }
}
