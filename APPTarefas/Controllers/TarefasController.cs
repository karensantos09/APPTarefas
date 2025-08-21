using APPTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTarefas.Controllers
{
    public class TarefasController : Controller
    {
        // Lista em memória(grava as informações apenas quando a aplicação está rodando)
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoId = 1;

        // GET: Tarefas
        public IActionResult Index()
        {
            return View(_tarefas); // Envia a lista de tarefas como parametro para a pagina Index.
        }

        // GET: Tarefas/Create
        // Get -> Metodo para "pegar" a pagina e exibir
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost] // Especifica que este método responde a requisições POST
        [ValidateAntiForgeryToken] // Protege contra ataques
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                // Atribui um ID único para a tarefa
                tarefa.TarefaId = _proximoId++;
                // Adiciona a tarefa à lista de tarefas (_tarefas)
                _tarefas.Add(tarefa);
                // Redireciona para a página Index
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        // GET: Tarefas/Edit/1
        public IActionResult Edit(int id)
        {
            // var tarefa = _tarefas[id];  // Trabalhando com Lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tarefa tarefaAtualizada)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Concluida = tarefaAtualizada.Concluida;

            return RedirectToAction("Index");

        }

        // GET: Tarefas/Details/1
        public IActionResult Details(int id)
        {
            // var tarefa = _tarefas[id];  // Trabalhando com Lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);
        }


        // GET: Tarefas/Delete/1
        public IActionResult Delete(int id)
        {
            // var tarefa = _tarefas[id];  // Trabalhando com Lista
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);
        }

        // POST: Tarefas/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
            }
            return RedirectToAction("Index");
        }





    }
}