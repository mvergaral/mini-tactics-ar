# 🧠 Mini Tactics AR

**Mini Tactics AR** es un juego táctico 1v1 desarrollado en Unity, que utiliza realidad aumentada (AR Foundation) para colocar un tablero sobre superficies del mundo real. El jugador puede ver dónde se han detectado planos, y luego interactuar tácticamente con casillas y unidades.

---

## 🚀 Características principales

- Colocación del tablero táctico en superficies reales detectadas
- Visualización de planos mediante feedback visual (material transparente)
- Generación dinámica de tablero (`Board.prefab`)
- Uso del nuevo **Input System** de Unity
- Soporte multiplataforma: **Android** y **iOS**
- Compatible con simulación en el editor (XR Simulation Environments)

---

## 📦 Requisitos

- Unity 2022.3 LTS o superior
- AR Foundation 5.x
- Input System Package
- XR Plug-in Management con ARCore (Android) y/o ARKit (iOS)
- Universal Render Pipeline (URP) (opcional pero recomendado)

---

## 🛠 Instalación y configuración

1. Clona este repositorio:

```bash
git clone https://github.com/tu-usuario/mini-tactics-ar.git
```

2. Abre el proyecto en Unity Hub
3. Instala los paquetes recomendados desde el Package Manager:
   - AR Foundation
   - ARKit XR Plugin (para iOS)
   - ARCore XR Plugin (para Android)
   - Input System
   - XR Simulation Environments

4. Ve a `Edit > Project Settings > Player` y asegúrate que:
   - **Active Input Handling** está en `Input System Package`
   - **XR Plug-in Management** tiene activado ARCore o ARKit según la plataforma

5. Usa la escena:

   ```
   Assets/_Game/Scenes/MiniTacticsAR_Main.unity
   ```

---

## 📱 Cómo probar en dispositivos

### Android

- Conecta tu teléfono y activa "Depuración USB"
- Abre `File > Build Settings`, selecciona `Android`, y haz clic en **Build and Run**

### iOS

- Abre `File > Build Settings`, selecciona `iOS`, y clic en **Build**
- Abre el proyecto generado en Xcode y ejecuta en tu iPhone

---

## 💡 Controles y flujo

- Al abrir la app, se escanean planos del entorno
- Se muestran zonas detectadas con un plano visual transparente
- El usuario **toca la pantalla** para colocar el tablero (solo una vez)
- Luego se puede interactuar con las casillas (en desarrollo)

---

## 📂 Estructura del proyecto

```plaintext
Assets/
├── _Game/
│   ├── Scripts/            # Lógica del tablero, input, raycasts
│   ├── Board/              # Prefab del tablero y tiles
│   ├── Materials/          # Materiales del plano y otros elementos
│   └── Scenes/             # Escena principal MiniTacticsAR_Main.unity
│   └── Prefabs/            # Prefabs planos, etc.
```

---

## ✨ Créditos

Desarrollado por **Matías Vergara**
Tecnologías: Unity, AR Foundation, Input System

---

## 📌 Próximos pasos

- Selección de casillas (`Tile`) y movimiento por turnos
- Colocación de unidades
- UI para feedback de turno y estado del juego
- Modo multijugador local
