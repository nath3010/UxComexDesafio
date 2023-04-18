using Microsoft.AspNetCore.Mvc;
using UxComexDesafio.Models;
using UxComexDesafio.Repository;

namespace UxComexDesafio.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoasRepository _pessoasRepository;

        public PessoasController(IPessoasRepository pessoasRepository)

        {
            _pessoasRepository = pessoasRepository;

        }

        public IActionResult Index()
        {
            return View(_pessoasRepository.GetAll());
        }


        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pessoa pessoa)
        {

            _pessoasRepository.Add(pessoa);
  
            return RedirectToAction("Edit", "Pessoas", new { @id = pessoa.Pessoaid });


        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var pessoa = _pessoasRepository.GetPessoaWithEndereco(id.GetValueOrDefault());

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(Pessoa pessoa)
        {
            _pessoasRepository.Update(pessoa);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var pessoa = _pessoasRepository.Find(id.GetValueOrDefault());

            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id) 
        {
            
            
            if(id == null || id == 0) 
            { 
                return NotFound(); 
            }

            _pessoasRepository.Remove(id.GetValueOrDefault());
               
            return RedirectToAction("Index");


        }

    }
}
