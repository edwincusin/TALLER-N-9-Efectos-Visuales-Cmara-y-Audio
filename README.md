# Taller N° 9: Efectos Visuales, Cámara y Audio

Proyecto 2D desarrollado en **Unity 6** donde se implementan mecánicas de pulido visual y auditivo (*Game Juice*): partículas de polvo al saltar, sacudida de cámara al recibir daño y un gestor centralizado de audio.

## Objetivo

Implementar efectos de pulido profesional en un juego 2D:

- Sistema de partículas para el polvo al despegar en cada salto.
- Sacudida de pantalla al recibir impactos.
- Gestor de audio centralizado para música de fondo en bucle y efectos de sonido (SFX).

## Características

### 1. Polvo al saltar (`PolvoSalto`)

Prefab con un **Particle System** que se instancia al despegar del suelo.

| Parámetro | Valor |
|---|---|
| Duration | 0.3 |
| Looping | Desactivado |
| Simulation Space | World |
| Emission Burst (Count) | 10 |
| Rate over Time | 0 |
| Shape | Circle (Radius 0.1) |
| Stop Action | Destroy |

El prefab se encuentra en `Assets/Prefabs` y se instancia desde `PlayerController.cs`:

```csharp
Instantiate(polvoSaltoPrefab, transform.position, Quaternion.identity);
```

### 2. Sacudida de cámara (`CameraShake.cs`)

- Usa el patrón **Singleton** (`CameraShake.Instancia`).
- Se asigna al objeto **Main Camera**.
- Se invoca desde `PlayerHealth.cs` al recibir daño de un enemigo o trampa:

```csharp
CameraShake.Instancia.Sacudir(0.2f, 0.2f);
```

Parámetros: `duracion` (segundos del temblor) y `fuerza` (desplazamiento máximo de la cámara).

### 3. Gestor de audio (`AudioManager.cs`)

- Patrón **Singleton** con `DontDestroyOnLoad(gameObject)`, por lo que el audio persiste entre escenas.
- Dos componentes `AudioSource`: uno para la **música en bucle** y otro para los **efectos SFX**.
- Método público para reproducir efectos:

```csharp
AudioManager.Instancia.ReproducirSfx(clip);
```

Sonidos implementados:

| Evento | Script | Clip |
|---|---|---|
| Saltar | `PlayerController.cs` | `clipSalto` |
| Atacar | `PlayerAttack.cs` | `clipAtaque` |
| Recibir daño | `PlayerHealth.cs` | `clipDano` |
| Recolectar moneda | `Coin.cs` | `clipMoneda` |

## Estructura de scripts

```
Assets/
├── Prefabs/
│   └── PolvoSalto.prefab
└── Scripts/
    ├── PlayerController.cs   # Movimiento, salto, polvo y sonido de salto
    ├── PlayerHealth.cs       # Daño, sacudida de cámara y sonido de daño
    ├── PlayerAttack.cs       # Ataque y sonido de ataque
    ├── Coin.cs               # Recolección de monedas y sonido
    ├── CameraShake.cs        # Sacudida de cámara (Singleton)
    └── AudioManager.cs       # Música y SFX (Singleton)
```

## Cómo ejecutar el proyecto

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/TU_USUARIO/TU_REPOSITORIO.git
   ```
2. Abrir el proyecto con **Unity 6** desde Unity Hub.
3. Abrir la escena principal en `Assets/Scenes`.
4. Verificar en el Inspector que:
   - `CameraShake` esté asignado a **Main Camera**.
   - `AudioManager` tenga asignados los dos `AudioSource` y los clips de sonido.
   - El Player tenga asignado el prefab `PolvoSalto`.
5. Pulsar **Play**.

### Controles

| Tecla | Acción |
|---|---|
| `A` / `D` o flechas | Mover al personaje |
| `Espacio` | Saltar |

## Video demostrativo

El video de demostración (máx. 10 segundos) muestra al personaje:

- Saltando (polvo y SFX de salto).
- Recolectando una moneda (SFX de moneda).
- Recibiendo daño de un enemigo (temblor de cámara).

**Dónde se compartió:**

- 📱 En el **grupo de WhatsApp del curso**.
- 🐙 En este **repositorio de GitHub**, con el nombre de archivo **`VideoTaller9`**.

## Autor

- **Nombre:** EDWINCSN
- **Taller:** N° 9, Efectos Visuales, Cámara y Audio