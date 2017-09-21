﻿using System;
using System.Linq;

namespace OneRosterProviderDemo.Models
{
    public static class SeedData
    {
        public static void Initialize(ApiContext context)
        {
            if (context.AcademicSessions.Any())
            {
                return;
            }

            context.AcademicSessions.AddRange(
                new AcademicSession()
                {
                    Id = "academic-session-1",
                    Status = Vocabulary.StatusType.inactive,
                    Title = "Spring Term",
                    StartDate = DateTime.Parse("2017-02-15"),
                    EndDate = DateTime.Parse("2017-06-15"),
                    Type = Vocabulary.SessionType.term,
                    SchoolYear = "2017"
                },
                new AcademicSession()
                {
                    Id = "academic-session-2",
                    Status = Vocabulary.StatusType.active,
                    Title = "Summer Term",
                    StartDate = DateTime.Parse("2017-06-21"),
                    EndDate = DateTime.Parse("2017-08-21"),
                    Type = Vocabulary.SessionType.term,
                    SchoolYear = "2017"
                },
                new AcademicSession()
                {
                    Id = "academic-session-3",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Summer First Half",
                    StartDate = DateTime.Parse("2017-06-21"),
                    EndDate = DateTime.Parse("2017-07-20"),
                    Type = Vocabulary.SessionType.gradingPeriod,
                    SchoolYear = "2017",
                    ParentAcademicSessionId = "academic-session-2"
                },
                new AcademicSession()
                {
                    Id = "academic-session-4",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Summer Second Half",
                    StartDate = DateTime.Parse("2017-07-21"),
                    EndDate = DateTime.Parse("2017-08-21"),
                    Type = Vocabulary.SessionType.gradingPeriod,
                    SchoolYear = "2017",
                    ParentAcademicSessionId = "academic-session-2"
                }
            );

            context.Orgs.AddRange(
                new Org()
                {
                    Id = "org-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Type = Vocabulary.OrgType.district,
                    Name = "Superhero School District",
                    Identifier = "CONTOSO-SUPERHEROES"
                },
                new Org()
                {
                    Id = "org-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Type = Vocabulary.OrgType.school,
                    Name = "Superhero Prep School",
                    ParentOrgId = "org-1",
                    Identifier = "CONTOSO-PREP"
                }
            );

            context.LineItemCategories.AddRange(
                new LineItemCategory()
                {
                    Id = "category-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Homework"
                },
                new LineItemCategory()
                {
                    Id = "category-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Labwork"
                }
            );

            context.Courses.AddRange(
                new Course()
                {
                    Id = "course-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Advanced Caffeination Techniques",
                    SchoolYearAcademicSessionId = "academic-session-2",
                    CourseCode = "CAF304",
                    OrgId = "org-2",
                    Grades = new string[] { "13", "UG" },
                    SubjectCodes = new string[] { "03098" }
                }
            );


            context.Klasses.AddRange(
                new Klass()
                {
                    Id = "class-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Advanced Caffeination Techniques",
                    ClassCode = "CAF304-2017A",
                    ClassType = Vocabulary.KlassType.scheduled,
                    Location = "Chemistry Lab 4",
                    CourseId = "course-1",
                    SchoolOrgId = "org-2",
                    Grades = new string[] { "13", "UG" },
                    SubjectCodes = new string[] { "03098" },
                    Periods = new string[] { "1" }
                },
                new Klass()
                {
                    Id = "class-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Advanced Caffeination Techniques",
                    ClassCode = "CAF304-2017B",
                    ClassType = Vocabulary.KlassType.scheduled,
                    Location = "Chemistry Lab 4",
                    CourseId = "course-1",
                    SchoolOrgId = "org-2",
                    Grades = new string[] { "13", "UG" },
                    SubjectCodes = new string[] { "03098" },
                    Periods = new string[] { "3", "6" }
                }
            );

            context.LineItems.AddRange(
                new LineItem()
                {
                    Id = "line-item-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Drink Coffee",
                    Description = "You must drink at least one cup of coffee, no decaf",
                    AssignDate = DateTime.Parse("2017-03-01"),
                    DueDate = DateTime.Parse("2017-04-01"),
                    KlassId = "class-1",
                    LineItemCategoryId = "category-1",
                    AcademicSessionId = "academic-session-1",
                    ResultValueMin = 0,
                    ResultValueMax = 100
                },
                new LineItem()
                {
                    Id = "line-item-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Title = "Intravenous Application",
                    AssignDate = DateTime.Parse("2017-04-05"),
                    DueDate = DateTime.Parse("2017-04-05"),
                    KlassId = "class-1",
                    LineItemCategoryId = "category-2",
                    AcademicSessionId = "academic-session-1",
                    ResultValueMin = 0,
                    ResultValueMax = 100
                }
            );

            context.Users.AddRange(
                new User()
                {
                    Id = "user-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Username = "alicer",
                    EnabledUser = true,
                    GivenName = "Alice",
                    MiddleName = "Pretend",
                    FamilyName = "Realperson",
                    Role = Vocabulary.RoleType.student,
                    Identifier = "legacy-identifier-user-1",
                    Email = "alice@siimpl.io",
                    SMS = "+1 234 567 8901",
                    Phone = "+1 234 567 8901",
                    Grades = new string[] { "UG" },
                    UserIds = new UserId[]
                    {
                        new UserId()
                        {
                            Type = "legacy-system-1",
                            Identifier = "legacy-identifier-user-1"
                        },
                        new UserId()
                        {
                            Type = "personal-email",
                            Identifier = "alice.realperson@emailprovider.com"
                        }
                    },
                    Password = "cGFzc3dvcmQ="
                },
                new User()
                {
                    Id = "user-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Username = "brianf",
                    EnabledUser = true,
                    GivenName = "Brian",
                    MiddleName = "Knot",
                    FamilyName = "Fakeperson",
                    Role = Vocabulary.RoleType.teacher,
                    Identifier = "legacy-identifier-user-2",
                    Email = "brian@siimpl.io",
                    SMS = "+1 345 678 9012",
                    Phone = "+1 345 678 9012",
                    Grades = new string[] { "UG" },
                    UserIds = new UserId[]
                    {
                        new UserId()
                        {
                            Type = "legacy-system-1",
                            Identifier = "legacy-identifier-user-2"
                        },
                        new UserId()
                        {
                            Type = "legacy-system-0",
                            Identifier = "brian+fakeperson+teacher+1995"
                        }
                    }
                },
                new User()
                {
                    Id = "user-3",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Username = "ever",
                    EnabledUser = true,
                    GivenName = "Eve",
                    FamilyName = "Reallyfakeperson",
                    Role = Vocabulary.RoleType.teacher,
                    Email = "eve@siimpl.io",
                    Grades = new string[] { "09", "10", "11", "12", "UG" },
                    Identifier = "legacy-system-user-3",
                    UserIds = new UserId[]
                    {
                        new UserId()
                        {
                            Type = "legacy-system-1",
                            Identifier = "legacy-identifier-user-3"
                        }
                    }
                },
                new User()
                {
                    Id = "user-4",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Username = "admin@siimpl.io",
                    EnabledUser = true,
                    GivenName = "Contoso",
                    FamilyName = "Admin",
                    Role = Vocabulary.RoleType.administrator,
                    Email = "admin@siimpl.io",
                    Grades = new string[] { },
                    Identifier = "root-admin"
                }
            );

            context.Enrollments.AddRange(
                new Enrollment()
                {
                    Id = "enrollment-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Role = Vocabulary.RoleType.teacher,
                    UserId = "user-2",
                    KlassId = "class-1",
                    SchoolOrgId = "org-2"
                },
                new Enrollment()
                {
                    Id = "enrollment-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    Role = Vocabulary.RoleType.student,
                    UserId = "user-1",
                    KlassId = "class-1",
                    SchoolOrgId = "org-2"
                }
            );

            context.Results.AddRange(
                new Result()
                {
                    Id = "result-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    LineItemId = "line-item-1",
                    StudentUserId = "user-1",
                    ScoreStatus = Vocabulary.ScoreStatus.fully_graded,
                    Score = 75.4f,
                    ScoreDate = DateTime.Parse("2017-04-20")
                },
                new Result()
                {
                    Id = "result-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    LineItemId = "line-item-2",
                    StudentUserId = "user-1",
                    ScoreStatus = Vocabulary.ScoreStatus.partially_graded,
                    Score = 95.3f,
                    ScoreDate = DateTime.Parse("2017-04-10")
                }
            );

            context.KlassAcademicSessions.AddRange(
                new KlassAcademicSession()
                {
                    Id = "class-academic-session-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    KlassId = "class-1",
                    AcademicSessionId = "academic-session-1"
                }
            );

            context.UserAgents.AddRange(
                new UserAgent()
                {
                    Id = "user-agent-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    SubjectUserId = "user-2",
                    AgentUserId = "user-3"
                }
            );

            context.UserOrgs.AddRange(
                new UserOrg()
                {
                    Id = "user-org-1",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    UserId = "user-1",
                    OrgId = "org-2"
                },
                new UserOrg()
                {
                    Id = "user-org-2",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    UserId = "user-2",
                    OrgId = "org-2"
                },
                new UserOrg()
                {
                    Id = "user-org-3",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    UserId = "user-3",
                    OrgId = "org-1"
                },
                new UserOrg()
                {
                    Id = "user-org-4",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    UserId = "user-3",
                    OrgId = "org-2"
                },
                new UserOrg()
                {
                    Id = "user-org-5",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    UserId = "user-4",
                    OrgId = "org-1"
                },
                new UserOrg()
                {
                    Id = "user-org-6",
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    Status = Vocabulary.StatusType.active,
                    UserId = "user-4",
                    OrgId = "org-2"
                }
            );

            context.SaveChanges();
        }
    }
}
