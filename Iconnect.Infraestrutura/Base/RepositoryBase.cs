using Microsoft.EntityFrameworkCore.ChangeTracking;
using Iconnect.Infraestrutura.Interfaces;
using Iconnect.Infraestrutura.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Iconnect.Infraestrutura.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        List<string> tabelasUpper = new List<string>() { "tb_ace_acesso",
            "tb_par_parametros",
            "tb_csr_connectionsignalr",
            "tb_cac_controleacesso",
            "tb_bio_biometria",
            "tb_dva_duvidasapp"};
        List<string> propriedades = new List<string>() {
            "cli_c_senha", "ddv_c_usuario" , "zec_ace_c_login","con_c_usuario","opl_c_login","rel_c_login",
            "ddv_c_senha","cac_c_senha","con_c_senha", "opl_c_senha", "rel_c_senha","cli_c_senhaappgarenconnect",
            "cli_c_dominiosip","cli_c_senhasip", "ema_c_corpo","ema_c_destinatario","ema_c_copiaoculta","cal_c_website","cat_c_link","fot_c_url" };

        protected IconnectCoreContext Context { get; set; }
        public RepositoryBase(IconnectCoreContext context) => Context = context;

        private DbSet<T> _entities;

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = Context.Set<T>();
                }
                return _entities;
            }
        }

        public IQueryable<T> List
        {
            get { return Entities; }
        }
        public void entityToUpper()
        {
            foreach (var item in Context.ChangeTracker.Entries())
            {
                Type entityType = item.Entity.GetType();
                if (tabelasUpper.Contains(entityType.Name.ToLower()))
                {
                    continue;
                }
                foreach (var entityProperty in entityType.GetProperties())
                {
                    if (propriedades.Contains(entityProperty.Name.ToLower()) || entityProperty.Name.Contains("_unique"))
                    {
                        continue;
                    }
                    if (entityProperty.PropertyType == typeof(string))
                    {
                        entityProperty.SetValue(item.Entity, entityProperty.GetValue(item.Entity, null) != null ? Convert.ToString(entityProperty.GetValue(item.Entity, null)).ToUpper() : null, null);
                    }
                }
            }
        }
        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> exp)
        {
            var iQueryableResult = await Context.Set<T>().Where(exp).ToListAsync();
            return iQueryableResult.AsQueryable();
        }

        public EntityEntry<T> Attach(T entity)
        {
            return Context.Attach(entity);
        }

        public async Task<IQueryable<T>> Find()
        {
            var iQueryableResult = await Context.Set<T>().ToListAsync();
            return iQueryableResult.AsQueryable();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Insert(T entity)
        {

            Context.Set<T>().Add(entity);
            entityToUpper();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            //entityToUpper();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        //public async Task<T> ExecuteSQL(string query)
        //{
        //    return await Context.Set<T>().FromSql(query).FirstOrDefaultAsync();
        //}

    }

}
