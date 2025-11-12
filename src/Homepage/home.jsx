import React from "react";
import "./home.css";
import NavBar from "../Navbar/NavBar.jsx";

function HomePage() {
    return (
        <div className="homepage">
            <header className="header">
                <NavBar/>
            </header>

            <main className="wrapper">
                <section className="left">
                    <img
                        className="product-img"
                        src="https://images.unsplash.com/photo-1455587734955-081b22074882?q=80&w=1200&auto=format&fit=crop"
                        alt="Hyacint Midnight Mystic"
                    />
                    <div className="chip">Huidige bod €100.000</div>
                    <div className="cta">
                        <button className="btn">Koop nu</button>
                    </div>
                </section>

                <section className="center">
                    <h2>Naam: Hyacinth 'Midnight Mystic'</h2>
                    <dl className="kv">
                        <dt>Bloei periode</dt>
                        <dd>Voorjaar</dd>
                        <dt>Hoeveelheid</dt>
                        <dd>1</dd>
                        <dt>Startprijs</dt>
                        <dd>€150.000</dd>
                        <dt>Aanvoerder</dt>
                        <dd>GreenGrow BV</dd>
                    </dl>
                </section>

                <aside className="right">
                    <div className="price-legend">
                        <div>€150.000</div>
                        <div>€100.000</div>
                    </div>
                    <div className="graph">
                        <div className="price-line"></div>
                        <div className="arrow"></div>
                    </div>
                    <div className="timer">
                        <small>resterende tijd :</small>
                        <strong>2d, 14h, 24min</strong>
                    </div>
                </aside>

                <section className="section">
                    <h3>Overige producten</h3>
                    <div className="cards">
                        {[
                            {
                                img: "https://images.unsplash.com/photo-1619258059605-e949f84f1bf8?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1169",
                                name: "Snowdrops",
                                price: "€1.850",
                            },
                            {
                                img: "https://images.unsplash.com/photo-1683303142347-3c41b18271a5?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1170",
                                name: "Hepaticas",
                                price: "€450",
                            },
                            {
                                img: "https://plus.unsplash.com/premium_photo-1756487224788-65e626badfb4?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1170",
                                name: "Cloud-pruned trees",
                                price: "€4.500",
                            },
                        ].map((item, i) => (
                            <article key={i} className="card">
                                <img src={item.img} alt={item.name} />
                                <div className="card-body">
                                    <h4>{item.name}</h4>
                                    <div className="price">{item.price}</div>
                                </div>
                                <div className="card-actions">
                                    <button className="btn-ghost">Bekijk</button>
                                    <div className="bookmark">🔖</div>
                                </div>
                            </article>
                        ))}
                        <div className="see-more">
                            <a className="btn-ghost" href="#">
                                zie meer →
                            </a>
                        </div>
                    </div>
                </section>
            </main>
        </div>
    );
}

export default HomePage;
