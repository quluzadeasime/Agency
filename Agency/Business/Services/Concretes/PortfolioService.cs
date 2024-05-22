using Business.Exceptions;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class PortfolioService : IPortfolioService
    {
        IPortfolioRepository _portfolioRepository;
        IWebHostEnvironment _environment;

        public PortfolioService(IPortfolioRepository portfolioRepository, IWebHostEnvironment environment = null)
        {
            _portfolioRepository = portfolioRepository;
            _environment = environment;
        }

        public void Add(Portfolio portfolio)
        {
            if (portfolio == null) throw new PortfolioNullException("", "Portfolio null ola bilmez");
            if (portfolio.PhotoFile == null) throw new PhotoNullException("", "Photo null ola bilmez!");
            if (portfolio.PhotoFile.FileName.Contains("image/")) throw new ContentTypeException("PhotoFile", "Tipi sehvdir");
            if (portfolio.PhotoFile.Length > 2097152) throw new FileSizeException("", "Max olcu 2 mb ola biler!");

            string path = _environment.WebRootPath + @"\uploads\" + portfolio.PhotoFile.FileName;

            using(FileStream file = new FileStream(path, FileMode.Create))
            {
                portfolio.PhotoFile.CopyTo(file);
            }

            portfolio.ImgUrl = portfolio.PhotoFile.FileName;
            _portfolioRepository.Add(portfolio);
            _portfolioRepository.Commit();


        }

        public void Delete(int id)
        {
            var existPortfolio = _portfolioRepository.Get(x=>x.Id == id);
            if (existPortfolio == null) throw new PortfolioNotFound("", "Portfolio yoxdur");

            string path = _environment.WebRootPath + @"\uploads\" + existPortfolio.ImgUrl;

            if (!File.Exists(path)) throw new Exceptions.FileNotFoundException("", "File yoxdur");

            File.Delete(path);
            _portfolioRepository.Delete(existPortfolio);
            _portfolioRepository.Commit();

        }

        public Portfolio Get(Func<Portfolio, bool>? func = null)
        {
            return _portfolioRepository.Get(func);
        }

        public List<Portfolio> GetAll(Func<Portfolio, bool>? func = null)
        {
            return (_portfolioRepository.GetAll(func));
        }

        public void Update(int id, Portfolio portfolio)
        {
            var existPortfolio = _portfolioRepository.Get(x => x.Id == id);
            if (existPortfolio == null) throw new PortfolioNotFound("", "Portfolio yoxdur");
            if (portfolio == null) throw new PortfolioNullException("", "Portfolio null ola bilmez");


            if (portfolio.PhotoFile != null)
            {
                if (!portfolio.PhotoFile.ContentType.Contains("image/")) throw new ContentTypeException("PhotoFile", "Tipi sehvdir");
                if (portfolio.PhotoFile.Length > 2097152) throw new FileSizeException("PhotoFile", "Max olcu 2 mb ola biler!");

                string path = _environment.WebRootPath + @"\uploads\" + portfolio.PhotoFile.FileName;

                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    portfolio.PhotoFile.CopyTo(file);
                }

                portfolio.ImgUrl = portfolio.PhotoFile.FileName;
                existPortfolio.ImgUrl = portfolio.ImgUrl;
            }
            existPortfolio.Title = portfolio.Title;
            existPortfolio.Subtitle = portfolio.Subtitle;
            _portfolioRepository.Commit();
        }
    }
}
