﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CB
{
    public class KhoaBoiDuongTapHuanThamGiaCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public KhoaBoiDuongTapHuanThamGiaCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoaBoiDuongTapHuanThamGiaCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdLoaiBoiDuongNavigation).Include(t => t.IdNguonKinhPhiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoaBoiDuongTapHuanThamGiaCuaCanBo = await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiBoiDuongNavigation)
                .Include(t => t.IdNguonKinhPhiNavigation)
                .FirstOrDefaultAsync(m => m.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo == id);
            if (tbKhoaBoiDuongTapHuanThamGiaCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
        }

        // GET: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdLoaiBoiDuong"] = new SelectList(_context.DmLoaiBoiDuongs, "IdLoaiBoiDuong", "IdLoaiBoiDuong");
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi");
            return View();
        }

        // POST: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoaBoiDuongTapHuanThamGiaCuaCanBo,IdCanBo,TenKhoaBoiDuongTapHuan,DonViToChuc,IdLoaiBoiDuong,DiaDiemToChuc,ThoiGianBatDau,ThoiGianKetThuc,IdNguonKinhPhi,ChungChi,NgayCap")] TbKhoaBoiDuongTapHuanThamGiaCuaCanBo tbKhoaBoiDuongTapHuanThamGiaCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdCanBo);
            ViewData["IdLoaiBoiDuong"] = new SelectList(_context.DmLoaiBoiDuongs, "IdLoaiBoiDuong", "IdLoaiBoiDuong", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdLoaiBoiDuong);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdNguonKinhPhi);
            return View(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
        }

        // GET: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoaBoiDuongTapHuanThamGiaCuaCanBo = await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.FindAsync(id);
            if (tbKhoaBoiDuongTapHuanThamGiaCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdCanBo);
            ViewData["IdLoaiBoiDuong"] = new SelectList(_context.DmLoaiBoiDuongs, "IdLoaiBoiDuong", "IdLoaiBoiDuong", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdLoaiBoiDuong);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdNguonKinhPhi);
            return View(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
        }

        // POST: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoaBoiDuongTapHuanThamGiaCuaCanBo,IdCanBo,TenKhoaBoiDuongTapHuan,DonViToChuc,IdLoaiBoiDuong,DiaDiemToChuc,ThoiGianBatDau,ThoiGianKetThuc,IdNguonKinhPhi,ChungChi,NgayCap")] TbKhoaBoiDuongTapHuanThamGiaCuaCanBo tbKhoaBoiDuongTapHuanThamGiaCuaCanBo)
        {
            if (id != tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoaBoiDuongTapHuanThamGiaCuaCanBoExists(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdCanBo);
            ViewData["IdLoaiBoiDuong"] = new SelectList(_context.DmLoaiBoiDuongs, "IdLoaiBoiDuong", "IdLoaiBoiDuong", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdLoaiBoiDuong);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdNguonKinhPhi);
            return View(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
        }

        // GET: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoaBoiDuongTapHuanThamGiaCuaCanBo = await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLoaiBoiDuongNavigation)
                .Include(t => t.IdNguonKinhPhiNavigation)
                .FirstOrDefaultAsync(m => m.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo == id);
            if (tbKhoaBoiDuongTapHuanThamGiaCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
        }

        // POST: KhoaBoiDuongTapHuanThamGiaCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoaBoiDuongTapHuanThamGiaCuaCanBo = await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.FindAsync(id);
            if (tbKhoaBoiDuongTapHuanThamGiaCuaCanBo != null)
            {
                _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.Remove(tbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoaBoiDuongTapHuanThamGiaCuaCanBoExists(int id)
        {
            return _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.Any(e => e.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo == id);
        }
    }
}
