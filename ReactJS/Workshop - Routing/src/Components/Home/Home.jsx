export default function Home() {
    return (
        <section
            className="flex flex-col h-screen font-mono"
            id="welcome-world"
        >
            <div className="welcome-message flex flex-col items-center overflow-hidden break-words pb-14 w-full font-extrabold tracking-tight z-10 pt-24">
                <p className="text-white text-5xl">
                    Where Every Pixel Comes to Life.
                </p>
            </div>

            <img
                src="./images/DBD-Alien.png"
                alt="hero"
                className="w-[70rem] h-[70rem]"
            />

            <div id="home-page" className="w-full h-full">
                <h1>Latest Games</h1>

                {/* <!-- Display div: with information about every game (if any) --> */}
                {/* <div className="game">
          <div className="image-wrap">
            <img src="./images/CoverFire.png" />
          </div>
          <h3>Cover Fire</h3>
          <div className="rating">
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
          </div>
          <div className="data-buttons">
            <a href="#" className="btn details-btn">
              Details
            </a>
          </div>
        </div>
        <div className="game">
          <div className="image-wrap">
            <img src="./images/ZombieLang.png" />
          </div>
          <h3>Zombie Lang</h3>
          <div className="rating">
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
          </div>
          <div className="data-buttons">
            <a href="#" className="btn details-btn">
              Details
            </a>
          </div>
        </div>
        <div className="game">
          <div className="image-wrap">
            <img src="./images/MineCraft.png" />
          </div>
          <h3>MineCraft</h3>
          <div className="rating">
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
            <span>☆</span>
          </div>
          <div className="data-buttons">
            <a href="#" className="btn details-btn">
              Details
            </a>
          </div>
        </div> */}

                {/* <!-- Display paragraph: If there is no games  --> */}
                <p className="no-articles">No games yet</p>
            </div>
        </section>
    );
}
