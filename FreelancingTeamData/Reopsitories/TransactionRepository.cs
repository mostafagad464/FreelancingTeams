using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;

namespace FreelancingTeamData.Reopsitories
{
    public class TransactionRepository:ITransaction<Transaction, ProjectPayment>
    {
        private readonly FreeLanceProjectContext db;
        public TransactionRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<Transaction> ProjectPayment(Transaction _Transaction)
        {
            try
            {
                var transaction = await db.Transactions.AddAsync(_Transaction);
                await db.SaveChangesAsync();
                
                if (transaction != null)
                    return transaction.Entity;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProjectPayment> RefundedMony( ProjectPayment _projectPayment)
        {
            try
            {
                var projectpayment =  db.ProjectPayments.Update(_projectPayment);
                await db.SaveChangesAsync();
                if (projectpayment != null)
                    return projectpayment.Entity;
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public async Task<ProjectPayment> TransferredMoney( ProjectPayment _projectPayment)
        {
            try
            {
                var projectpayment = db.ProjectPayments.Update(_projectPayment);
                await db.SaveChangesAsync();
                if (projectpayment != null)
                    return projectpayment.Entity;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public async Task<ICollection<TeamTransaction>> TeamTransactions(List<TeamTransaction> _objects)
        //{
        //    try
        //    {
        //        TeamTransaction teamTransaction = new TeamTransaction();
        //        List<TeamTransaction> teamTransactions = new List<TeamTransaction>();

        //        for (int i = 0; i < _objects.Count; i++)
        //        {
        //            TeamTransaction t = await db.TeamTransactions.AddAsync(_objects[i]);
        //            await db.SaveChangesAsync();
        //            teamTransactions.Add(t);
        //        }
        //        return teamTransactions;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
