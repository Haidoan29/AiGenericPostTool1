using AiGenericPostTool.Models;

namespace AiGenericPostTool.Data
{
    public static class DataInit
    {
        public static void InitData(ApplicationDbContext context)
        {
            //Tao ra class

            if(context.Platforms.Count() <= 0)
            {
                var platform1 = new Platform()
                {
                    Name = "Facebook",
                    Icon = "<i class=\"fa-brands fa-facebook\"></i>"
                };
                var platform2 = new Platform()
                {
                    Name = "Mail",
                    Icon = "<i class=\"fa-solid fa-envelope\"></i>"
                };
                var platform3 = new Platform()
                {
                    Name = "Instagram",
                    Icon = "<i class=\"fa-brands fa-instagram\"></i>"
                };

                context.Platforms.Add(platform1);
                context.Platforms.Add(platform2);
                context.Platforms.Add(platform3);
                context.SaveChanges();

                // Prompt
                if(context.Prompts.Count() <= 0 )
                {
                    var prompt1 = new Prompt()
                    {
                        Name = "Product Ads",
                        Content = "Hãy nhập vai một chuyên gia marketing, hướng tới đối tượng người đọc là người tiêu dùng thông minh" +
                                  "Sử dụng văn phong {tone}, xu hướng viết {writing_style}" +
                                  "Sử dụng cấu trúc văn bản {type}" +
                                  "Không diễn giải, không giải thích, không xin lỗi, tập trung hoàn thiện bài viết tốt nhất có thể" +
                                  "Viết cho tôi bài đăng facebook quảng cáo sản phẩm khoảng 100 từ, có sử dụng icon ở mỗi đầu và cuối dòng, bài đăng chuẩn bài đăng facebook hấp dẫn, phù hợp quảng cáo. Thêm vào cta thông tin của tôi là : {cta}",
                        PlatformId = platform1.Id

                        /*Thuong 1 prompt xin se gom 5 phan
                         Phan 1: Nhap vai - Huong toi doi tuong
                         Phan 2: Van phong, giong viet
                         Phan 3: Su dung 1 cau truc nao do
                         Phan 4: Native Prompt 
                         Phan 5: Dat ra yeu cau va gan keyword*/

                    };
                    var prompt2 = new Prompt()
                    {
                        Name = "Target Ads",
                        Content = "Viết cho tôi mô tả chi tiết về chiến dịch chạy quảng cáo facebook cho sản phẩm {keyword} với các phần như: Ngân sách, phân bố ngân sách, target đối tượng, a/b testing",
                        PlatformId = platform1.Id
                    };
                    var prompt3 = new Prompt()
                    {
                        Name = "Email ung tuyen",
                        Content = "Viết cho tôi email ứng tuyển với văn phong {tone}, tập trung vào mô tả kỹ năng cá nhân và lợi ích khi được tuyển dụng. Từ khoá cua tôi là {keyword}",
                        PlatformId = platform2.Id
                    };

                    context.Prompts.Add(prompt1);
                    context.Prompts.Add(prompt2);
                    context.Prompts.Add(prompt3);
                    context.SaveChanges();
                }

            }




        }

    }
}
