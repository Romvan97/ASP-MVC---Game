using Demo_ASP_MVC_Modele.BLL.Entities;
using Demo_ASP_MVC_Modele.BLL.Interfaces;
using Demo_ASP_MVC_Modele.BLL.Tools;
using Demo_ASP_MVC_Modele.DAL.Entities;
using Demo_ASP_MVC_Modele.DAL.Interfaces;
using Demo_ASP_MVC_Modele.DAL.Repositories;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_Modele.BLL.Services
{
    public class MemberService : IMemberService
    {
        // utilise l'injection de dépendence et crée la connection string de AppSettings.json
       private IMemberRepository _MemberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _MemberRepository = memberRepository;
        }

        public MemberModel Register(MemberModel member)
        {
            // Vérifie que l'utilisateur ou le mail n'existe pas déjà ! 

            bool error = false;
            string test = null;
            MemberModel testMemberPseudo = new();
            testMemberPseudo = _MemberRepository.GetAll().Select(m => m.ToBll()).SingleOrDefault(tm => tm.Pseudo == member.Pseudo);
            MemberModel testMemberEmail = new();
            testMemberEmail = _MemberRepository.GetAll().Select(m => m.ToBll()).SingleOrDefault(tm => tm.Email == member.Email);


            if (testMemberPseudo != null)
            {
                test = "Le pseudo existe déjà !!";
                error = true;
            }

            if (testMemberEmail != null)
            {
                test = test + " Cet email est déjà utiliser !!";
                error = true;
            }

            if (error)
            {
                throw new Exception(test);
            }

            // Fin de la vérification et envoie d'un ou deux message d'erreur

            /// Enregistrement de l'utilisateur

            // 1 - Hashage du mot de passe // Peut se faire dans la bll ou la db
            string pwdHash = Argon2.Hash(member.Pwd);

            // 2 - Ajout dans la DB
            MemberEntity mEntity = member.ToDAL();
            mEntity.PwdHash = pwdHash;

            int id = _MemberRepository.Insert(mEntity);

            // Recuperation du member
            return _MemberRepository.GetById(id).ToBll();
        }

        public MemberModel Login(string pseudo, string password)
        {
            // Récuperation du Hash lier au compte
            string hash = _MemberRepository.GetHashByPseudo(pseudo);

            if(string.IsNullOrWhiteSpace(hash))
            {
                throw new Exception("Utilisateur inexistant");
            }

            // Validation du hash avec le password
            if(Argon2.Verify(hash, password))
            {
                return _MemberRepository.GetByPseudo(pseudo).ToBll();
            }
            else
            {
                throw new Exception("Mot de passe incorrect");
            }
        }
    }
}
