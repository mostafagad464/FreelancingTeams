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
    public class TransactionRepository:ITransaction<Transaction>
    {
        private readonly FreeLanceProjectContext db;
        public TransactionRepository(FreeLanceProjectContext _db)
        {
            db = _db;
        }

        public async Task<Transaction> ProjectPayment(Transaction _object, int clientId, int projectId)
        {
            try
            {
                var transaction = await db.Transactions.AddAsync(_object);
                await db.SaveChangesAsync();
                

                //Transaction transaction = await db.Transactions.AddAsync(_object);
                if (transaction != null)
                {
                    //Transaction t = (Transaction) transaction;
                    //int transactionId = t.Id;
                    int transactionId = transaction.Entity.Id;
                    ProjectPayment projectPayment = new ProjectPayment();
                    projectPayment.ClientId = clientId;
                    projectPayment.ProjectId = projectId;
                    //projectPayment.TransactionId = t.Id;
                    projectPayment.TransactionId = transaction.Entity.Id;
                    await db.ProjectPayments.AddAsync(projectPayment);
                    await db.SaveChangesAsync();
                    return transaction.Entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<ICollection<TeamTransaction>> TeamTransactions(List<TeamTransaction> _objects)
        {
            try
            {

                TeamTransaction teamTransaction = new TeamTransaction();
                List<TeamTransaction> teamTransactions = new List<TeamTransaction>();

                for (int i = 0; i < _objects.Count; i++)
                {
                    TeamTransaction t = await db.TeamTransactions.AddAsync(_objects[i]);
                    await db.SaveChangesAsync();
                    teamTransactions.Add(t);
                }
                return teamTransactions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
