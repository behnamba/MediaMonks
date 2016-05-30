namespace PlanDay.Assignment.Data.Migrations
{
    using Core.ActionExecuter;
    using Core.PaymentRule;
    using Core.Product;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Mvc;
    internal sealed class Configuration : DbMigrationsConfiguration<PlanDay.Assignment.Data.EFConcrete.TestDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlanDay.Assignment.Data.EFConcrete.TestDataContext context)
        {
            //  This method will be called after migrating to the latest version.
            GenerateDummyData(context);
        }

        #region Generate Dummy Data
        public void GenerateDummyData(PlanDay.Assignment.Data.EFConcrete.TestDataContext context)
        {
            // product tags
            GenerateDummyProductTags(context);

            // Dummy payment Rules
            GenerateDummyRuleForPhysicalProduct(context);
            GenerateDummyRuleForASPBook(context);
            GenerateDummyRuleForMemberShip(context);
        }

        public void GenerateDummyProductTags(PlanDay.Assignment.Data.EFConcrete.TestDataContext context)
        {
            if (context.ProductTags.Count() > 0)
            {
                return;
            }

            // add product tags
            ProductTag physicalTag = new ProductTag
            {
                Name = "Physical"
            };

            ProductTag booksTag = new ProductTag
            {
                Name = "Books"
            };

            ProductTag memebershipTag = new ProductTag
            {
                Name = "Membership"
            };

            ProductTag upgradeTag = new ProductTag
            {
                Name = "Upgrade"
            };

            ProductTag videoTrainingTag = new ProductTag
            {
                Name = "Video training"
            };

            // add products to tags
            Product mp3Player = new Product
            {
                Price = 150,
                Title = "MP3 Player for Sale!"
            };
            physicalTag.Products.Add(mp3Player);
            mp3Player.ProductTag.Add(physicalTag);

            Product aspbook = new Product
            {
                Price = 85,
                Title = "Asp.net beginner"
            };
            physicalTag.Products.Add(aspbook);
            booksTag.Products.Add(aspbook);
            aspbook.ProductTag.Add(physicalTag);
            aspbook.ProductTag.Add(booksTag);

            Product oneYearMembership = new Product
            {
                Price = 200,
                Title = "buy one year membership!"
            };
            memebershipTag.Products.Add(oneYearMembership);
            oneYearMembership.ProductTag.Add(memebershipTag);

            Product upgradeYearMembership = new Product
            {
                Price = 50,
                Title = "upgrade your membership!"
            };
            upgradeTag.Products.Add(upgradeYearMembership);
            upgradeYearMembership.ProductTag.Add(upgradeTag);

            Product aspVideoTutarial = new Product
            {
                Price = 50,
                Title = "Asp video training!"
            };
            videoTrainingTag.Products.Add(aspVideoTutarial);
            aspVideoTutarial.ProductTag.Add(videoTrainingTag);

            Product htmlVideoTutarial = new Product
            {
                Price = 50,
                Title = "Html video training!"
            };
            videoTrainingTag.Products.Add(htmlVideoTutarial);
            htmlVideoTutarial.ProductTag.Add(videoTrainingTag);

            // save tags and products 
            context.ProductTags.Add(physicalTag);
            context.ProductTags.Add(booksTag);
            context.ProductTags.Add(memebershipTag);
            context.ProductTags.Add(upgradeTag);
            context.ProductTags.Add(videoTrainingTag);

            context.SaveChanges();
        }

        // If the payment is for a physical product, generate a package slip for shipping
        public void GenerateDummyRuleForPhysicalProduct(PlanDay.Assignment.Data.EFConcrete.TestDataContext context)
        {
            if (context.PaymentRules.Count(p=>p.Name.Equals("If the payment is for a physical product, generate a package slip for shipping")) > 0)
            {
                return;
            }
            // 
            PaymentRule paymentRuleForPhysicalProduct = new PaymentRule(new PaymentRuleHandler());
            paymentRuleForPhysicalProduct.Name = "If the payment is for a physical product, generate a package slip for shipping";

            Criteria criteria = new Criteria(new CriteriaRuleHandler());
            criteria.CriteriaType = CriteriaType.ProductTag;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.ChainedCriteria = ChainedCriteria.And;
            criteria.PaymentRule = paymentRuleForPhysicalProduct;
            criteria.Value = "1"; // Physical Tag Id 

            paymentRuleForPhysicalProduct.Criterias = new List<Criteria>();
            paymentRuleForPhysicalProduct.Criterias.Add(criteria);

            paymentRuleForPhysicalProduct.Actions = new List<Core.PaymentRule.Action>();
            paymentRuleForPhysicalProduct.Actions.Add(new Core.PaymentRule.Action
            {
                Name = "Generate a package slip",
                PaymentRule = paymentRuleForPhysicalProduct,
                Type = typeof(PackageSlip).ToString()
            });

            // save in DB
            context.PaymentRules.Add(paymentRuleForPhysicalProduct);
            context.SaveChanges();
        }

        // If the payment is for a physical product, generate a package slip for shipping
        public void GenerateDummyRuleForASPBook(PlanDay.Assignment.Data.EFConcrete.TestDataContext context)
        {
            if (context.PaymentRules.Count(p => p.Name.Equals("If the payment is for a book, create a duplicate packing slip for the royalty department")) > 0)
            {
                return;
            }

            PaymentRule paymentRuleForAspBookProduct = new PaymentRule(new PaymentRuleHandler());
            paymentRuleForAspBookProduct.Name = "If the payment is for a book, create a duplicate packing slip for the royalty department";

            Criteria criteria = new Criteria(new CriteriaRuleHandler());
            criteria.CriteriaType = CriteriaType.ProductTag;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.ChainedCriteria = ChainedCriteria.And;
            criteria.PaymentRule = paymentRuleForAspBookProduct;
            criteria.Value = "2"; // Physical Tag Id 

            paymentRuleForAspBookProduct.Criterias = new List<Criteria>();
            paymentRuleForAspBookProduct.Criterias.Add(criteria);

            paymentRuleForAspBookProduct.Actions = new List<Core.PaymentRule.Action>();
            paymentRuleForAspBookProduct.Actions.Add(new Core.PaymentRule.Action
            {
                Name = "Generate a second package slip for loyalty department",
                PaymentRule = paymentRuleForAspBookProduct,
                Type = typeof(PackageSlip).ToString()
            });

            // save in DB
            context.PaymentRules.Add(paymentRuleForAspBookProduct);
            context.SaveChanges();
        }


        // If the payment is for a membership, activate that membership.
        public void GenerateDummyRuleForMemberShip(PlanDay.Assignment.Data.EFConcrete.TestDataContext context)
        {
            if (context.PaymentRules.Count(p => p.Name.Equals("If the payment is for a membership, activate that membership")) > 0)
            {
                return;
            }

            PaymentRule paymentRuleForMemberShip = new PaymentRule(new PaymentRuleHandler());
            paymentRuleForMemberShip.Name = "If the payment is for a membership, activate that membership";

            Criteria criteria = new Criteria(new CriteriaRuleHandler());
            criteria.CriteriaType = CriteriaType.ProductTag;
            criteria.CriteriaOperator = CriteriaOperator.Equal;
            criteria.ChainedCriteria = ChainedCriteria.And;
            criteria.PaymentRule = paymentRuleForMemberShip;
            criteria.Value = "3"; // Physical Tag Id 

            paymentRuleForMemberShip.Criterias = new List<Criteria>();
            paymentRuleForMemberShip.Criterias.Add(criteria);

            paymentRuleForMemberShip.Actions = new List<Core.PaymentRule.Action>();
            paymentRuleForMemberShip.Actions.Add(new Core.PaymentRule.Action
            {
                Name = "Generate a package slip for membership",
                PaymentRule = paymentRuleForMemberShip,
                Type = typeof(PackageSlip).ToString()
            });

            paymentRuleForMemberShip.Actions.Add(new Core.PaymentRule.Action
            {
                Name = "Membership activate",
                PaymentRule = paymentRuleForMemberShip,
                Type = typeof(MembershipActivator).ToString()
            });

            // save in DB
            context.PaymentRules.Add(paymentRuleForMemberShip);
            context.SaveChanges();
        }
        #endregion
    }
}
