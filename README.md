# 🎮 TALLER N° 8: Sistema de Menús, Pausa In-Game y Navegación entre Escenas

Proyecto de juego 2D hecho en **Unity 6.3 LTS (6000.3.25f1)**.
En este taller se implementó la arquitectura completa de menús de un juego 2D: pantalla de inicio, navegación entre escenas, pausa In-Game y registro de escenas en Build Profiles.

---

## 🎯 Objetivo

Implementar un sistema de menús con:

- Pantalla de inicio (**MainMenu**).
- Navegación entre escenas con `SceneManager.LoadScene`.
- Sistema de pausa In-Game con congelamiento de físicas (`Time.timeScale = 0`).
- Registro oficial de las escenas en **Build Profiles / Build Settings**.

---

## 🎬 Video demostrativo

✅ **El video demostrativo está incluido en este repositorio** con el nombre **`VIDEOTALLER8`**.

📱 **También fue compartido en el grupo de WhatsApp** de la clase.

El video (máx. 10 segundos) muestra:

1. Inicio en la escena **MainMenu**.
2. Clic en **JUGAR** para entrar al **Nivel1**.
3. Pulsar **ESC** o **P** para congelar el juego y mostrar el menú de pausa.
4. Uso del botón **REANUDAR**.

---

## 🗂️ Escenas del proyecto

| Índice | Escena | Descripción |
|:---:|---|---|
| 0 | `MainMenu` | Pantalla de inicio con el título del juego y los botones **JUGAR** y **SALIR**. |
| 1 | `Nivel1` | Nivel principal del juego, con el menú de pausa In-Game. |

Las escenas están registradas en **File > Build Profiles (Build Settings)** en ese orden estricto.

---

## 📜 Scripts nuevos

### `MainMenu.cs`
Controla la pantalla de inicio.

| Función | Qué hace |
|---|---|
| `Jugar()` | Carga la escena del nivel principal (`Nivel1`). |
| `Salir()` | Cierra la aplicación con `Application.Quit()`. |

Las funciones públicas están conectadas en **On Click ()** de los botones **JUGAR** y **SALIR**.

### `PauseMenu.cs`
Controla el menú de pausa dentro del nivel.

| Función | Qué hace |
|---|---|
| `Update()` | Detecta las teclas **ESC** o **P** para pausar o reanudar. |
| `Pausa()` | Muestra el panel y fija `Time.timeScale = 0f`. |
| `Reanudar()` | Oculta el panel y fija `Time.timeScale = 1f`. |
| `Reiniciar()` | Restaura el tiempo y recarga la escena actual. |
| `IrAlMenu()` | Restaura el tiempo y vuelve a la escena `MainMenu`. |

---

## 🖼️ Interfaz

### Menú principal (MainMenu)
- Título del juego.
- Botón **JUGAR**.
- Botón **SALIR**.

### Menú de pausa (PanelPausa)
- Título **"JUEGO EN PAUSA"**.
- Botón **REANUDAR**.
- Botón **REINICIAR**.
- Botón **MENÚ PRINCIPAL**.
- El panel está **oculto por defecto** (casilla desmarcada en el Inspector).

---

## ⌨️ Controles

| Tecla | Acción |
|:---:|---|
| `ESC` o `P` | Pausar / reanudar el juego |

---

## ▶️ Cómo ejecutar el proyecto

1. Clona el repositorio:
   ```bash
   git clone <URL-DEL-REPOSITORIO>
   ```
2. Abre el proyecto con **Unity 6.3 LTS (6000.3.25f1)** desde Unity Hub.
3. Abre la escena **`MainMenu`** (`Assets/Scenes`).
4. Pulsa **Play**.

> ℹ️ Este repositorio usa **Git LFS**. Instálalo antes de clonar (`git lfs install`) para descargar correctamente los archivos grandes.

---

## 🛠️ Tecnologías

- Unity 6.3 LTS (6000.3.25f1)
- C#
- TextMeshPro y UI (Canvas)
- Git, GitHub y Git LFS

---

## 👤 Autor

**Nombre:** _(EdwinCsn)_
**Taller:** N° 8: Sistema de Menús, Pausa In-Game y Navegación entre Escenas
