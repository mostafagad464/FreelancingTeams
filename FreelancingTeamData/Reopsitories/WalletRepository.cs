using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancingTeamData.Reopsitories
{
    public class WalletRepository : IWallet<Wallet>
      
    {
        private FreeLanceProjectContext db=new FreeLanceProjectContext();

        public WalletRepository(FreeLanceProjectContext _db)
        {
            db= _db;
        }

        public async Task<Wallet> Create(Wallet wallet)
        {
            //if (db.Wallets == null)
            //{
            //    return null;
            //}
            try { 
                var newWallet = await db.Wallets.AddAsync(wallet);
                await db.SaveChangesAsync();

                return newWallet.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (db.Wallets == null)
            {
                return false;
            }
            var wallet = await db.Wallets.FindAsync(id);
            if (wallet == null)
            {
                return false;
            }

            db.Wallets.Remove(wallet);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Wallet>> GetAll()
        {
            if (db.Wallets == null)
            {
                return null;

            }
            try
            {
                return await db.Wallets.ToListAsync();

            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<Wallet> GetById(int id)
        {
            if (db.Wallets == null)
            {
                return null;
            }
            try
            {

                var wallet = await db.Wallets.FindAsync(id);

                if (wallet == null)
                {
                    return null;
                }


                return wallet;
            }
            catch(Exception ex)
            {
                return null;

            }
        }

        public async Task<Wallet> Update(Wallet wallet)
        {

            db.Entry(wallet).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletExists(wallet.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return wallet;
        }
        private bool WalletExists(int id)
        {
            return (db.Wallets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


    }

