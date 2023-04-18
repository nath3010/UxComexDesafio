using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UxComexDesafio.Models;
using UxComexDesafio.Repository;

namespace UxComexDesafio.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly IEnderecosRepository _enderecosRepositor;
        private readonly IPessoasRepository _pessoasRepository;

        public EnderecosController(IEnderecosRepository enderecosRepositor, IPessoasRepository pessoasRepository)

        {
            _enderecosRepositor = enderecosRepositor;
            _pessoasRepository = pessoasRepository;
        }


        public IActionResult Create(int? id)
        {

            ViewBag.pessoaId = id;
            TempData["idPessoa"] = id;

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Endereco endereco)
        {

            _enderecosRepositor.Add(endereco);

            int idPessoa = Convert.ToInt32(TempData["idPessoa"]);

            return RedirectToAction("Edit", "Pessoas", new { @id = idPessoa });

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var endereco = _enderecosRepositor.Find(id.GetValueOrDefault());

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Endereco endereco)
        {


            _enderecosRepositor.Update(endereco);
            return RedirectToAction("Edit", "Pessoas", new { @id = endereco.Pessoaid });


        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var endereco = _enderecosRepositor.Find(id.GetValueOrDefault());

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }


            _enderecosRepositor.Remove(id.GetValueOrDefault());

            return RedirectToAction("Index", "Pessoas");


        }





    }
}
